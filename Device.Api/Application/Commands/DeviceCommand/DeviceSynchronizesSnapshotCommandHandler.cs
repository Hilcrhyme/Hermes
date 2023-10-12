using Hermes.Common.IdentityGenerator;
using Hermes.Service.Device.Api.Application.Commands.PlatformCommand;
using Hermes.Service.Device.Api.Application.Query;
using Hermes.Service.Device.Domain.Aggregates.UpdatePlanAggregate;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands.DeviceCommand
{
    /// <summary>
    /// 设备同步快照命令处理器
    /// </summary>
    public class DeviceSynchronizesSnapshotCommandHandler : CommunicationCommandHandler<DeviceSynchronizesSnapshotCommand>
    {
        /// <summary>
        /// 设备查询
        /// </summary>
        private readonly IDeviceQuery deviceQuery;

        /// <summary>
        /// 更新计划查询
        /// </summary>
        private readonly IUpdatePlanQuery updatePlanQuery;

        /// <summary>
        /// Id 生成器
        /// </summary>
        private readonly IIdentityGenerator<long> identityGenerator;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<DeviceSynchronizesSnapshotCommandHandler> logger;

        /// <summary>
        /// 消息中介器
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// 实例化设备同步快照命令处理器
        /// </summary>
        /// <param name="deviceQuery">设备查询</param>
        /// <param name="updatePlanQuery">更新计划查询</param>
        /// <param name="identityGenerator">Id 生成器</param>
        /// <param name="logger">日志器</param>
        /// <param name="mediator">消息中介器</param>
        public DeviceSynchronizesSnapshotCommandHandler(IDeviceQuery deviceQuery, IUpdatePlanQuery updatePlanQuery, IIdentityGenerator<long> identityGenerator, ILogger<DeviceSynchronizesSnapshotCommandHandler> logger, IMediator mediator)
        {
            this.deviceQuery = deviceQuery;
            this.updatePlanQuery = updatePlanQuery;
            this.identityGenerator = identityGenerator;
            this.logger = logger;
            this.mediator = mediator;
        }

        /// <summary>
        /// 异步处理设备同步快照命令
        /// </summary>
        /// <param name="request">设备同步快照命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public override async Task Handle(DeviceSynchronizesSnapshotCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var snapshot = await deviceQuery.GetDeviceSnapshotAsync(request.DeviceCode);
                if (snapshot is null)
                {
                    logger.LogError();
                    return;
                }
                var result = await updatePlanQuery.QueryUpdateTasksAsync(new UpdateTaskQueryRequest()
                {
                    DeviceCode = request.DeviceCode,
                    UpdatePackageType = UpdateTargetType.Software,
                    UpdateTaskState = UpdateTaskState.Pushing,
                });
                foreach (var item in request.Data.Softwares)
                {
                    var tasks = result.Items.Where(updateTask => updateTask.TargetName == item.Name && updateTask.SupportedSoftwareVersions.Contains(item.Version));
                    if (!tasks.Any())
                    {
                        continue;
                    }
                    await mediator.Publish(new PlatformRequiresUpdateCommand(request.DeviceCode, new PlatformCommand.UpdateTask()
                    {
                        Id = await identityGenerator.GetNextIdAsync(),
                        TargetName = item.Name,
                        Version = tasks.First().UpdatedVersion,
                        PackageName = tasks.First().PackageName,
                        PackageSize = tasks.First().PackageSize,
                        PackageMD5 = tasks.First().PackageMD5,
                        PackageUrl = tasks.First().PackageUrl
                    }), cancellationToken);
                    // 每次只更新一个软件
                    break;
                }
            }
            catch (Exception)
            {
                logger.LogCritical();
            }
        }
    }
}