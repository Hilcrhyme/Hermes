using Hermes.Service.Device.Api.Application.Query;
using Hermes.Service.Device.Domain.Aggregate.DeviceAggregate;

namespace Hermes.Service.Device.Api.Application.Command.DeviceCommand
{
    /// <summary>
    /// 设备同步更新子任务进度命令处理器
    /// </summary>
    public class DeviceSynchronizeSubUpdateTaskProgressCommandHandler : CommunicationCommandHandler<DeviceSynchronizeSubUpdateTaskProgressCommand>
    {
        /// <summary>
        /// 设备查询
        /// </summary>
        private readonly IDeviceQuery deviceQuery;

        /// <summary>
        /// 设备领域服务
        /// </summary>
        private readonly IDeviceDomainService deviceDomainService;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<DeviceSynchronizeSubUpdateTaskProgressCommandHandler> logger;

        /// <summary>
        /// 实例化设备同步更新子任务进度命令处理器
        /// </summary>
        /// <param name="deviceQuery">设备查询</param>
        /// <param name="deviceDomainService">设备领域服务</param>
        /// <param name="logger">日志器</param>
        public DeviceSynchronizeSubUpdateTaskProgressCommandHandler(IDeviceQuery deviceQuery, IDeviceDomainService deviceDomainService, ILogger<DeviceSynchronizeSubUpdateTaskProgressCommandHandler> logger)
        {
            this.deviceQuery = deviceQuery;
            this.deviceDomainService = deviceDomainService;
            this.logger = logger;
        }

        /// <summary>
        /// 异步处理设备同步更新子任务进度命令
        /// </summary>
        /// <param name="request">设备同步更新子任务进度命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public override async Task Handle(DeviceSynchronizeSubUpdateTaskProgressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var task = await deviceQuery.GetSoftwareUpdateTaskAsync(request.Data.SubUpdateTaskId);
                if (task is null)
                {
                    logger.LogError();
                    return;
                }
                await deviceDomainService.UpdateSoftwareUpdateTaskProgressAsync(request.DeviceCode, new Domain.Aggregate.DeviceAggregate.SoftwareUpdateTaskProgress()
                {
                    SoftwareUpdateTaskId = task.Value.Id,
                    Value = request.Data.Value,
                    Message = request.Data.Message,
                    SynchronizedTime = DateTimeOffset.FromUnixTimeMilliseconds(request.Timestamp).DateTime
                });
            }
            catch (Exception ex)
            {
                logger.LogCritical();
            }
        }
    }
}