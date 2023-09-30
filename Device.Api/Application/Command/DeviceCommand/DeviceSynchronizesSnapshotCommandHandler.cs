using Hermes.Common.IdentityGenerator;
using Hermes.Service.Device.Api.Application.Command.PlatformCommand;
using Hermes.Service.Device.Api.Application.Query;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Command.DeviceCommand
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
        /// <param name="identityGenerator">Id 生成器</param>
        /// <param name="logger">日志器</param>
        /// <param name="mediator">消息中介器</param>
        public DeviceSynchronizesSnapshotCommandHandler(IDeviceQuery deviceQuery, IIdentityGenerator<long> identityGenerator, ILogger<DeviceSynchronizesSnapshotCommandHandler> logger, IMediator mediator)
        {
            this.deviceQuery = deviceQuery;
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
                var updateTasks = await deviceQuery.GetSoftwareUpdateTasksAsync(request.DeviceCode);
                foreach (var item in request.Data.Softwares)
                {
                    var task = updateTasks.FirstOrDefault(updateTask => updateTask.Name == item.Name && updateTask.SupportedSoftwareVersions.Contains(item.Version));
                    if (task is null)
                    {
                        continue;
                    }
                    await mediator.Publish(new PlatformRequiresUpdateSoftwareCommand(request.DeviceCode, new SoftwareUpdateTask()
                    {
                        TaskId = await identityGenerator.GetNextIdAsync(),
                        SoftwareName = item.Name,
                        SoftwareVersion = task.UpdatedVersion,
                        PackageName = task.PackageName,
                        PackageSize = task.PackageSize,
                        PackageMD5 = task.PackageMD5,
                        PackageUrl = task.PackageUrl
                    }), cancellationToken);
                    // 每次只更新一个软件
                    break;
                }
            }
            catch (Exception ex)
            {
                logger.LogCritical();
            }
        }
    }
}