using Hermes.Service.Device.Domain.Aggregates.DeviceAggregate;

namespace Hermes.Service.Device.Api.Application.Commands.DeviceCommand
{
    /// <summary>
    /// 设备同步控制任务响应命令处理器
    /// </summary>
    public class DeviceSynchronizesControlTaskResponseCommandHandler : CommunicationCommandHandler<DeviceSynchronizesControlTaskResponseCommand>
    {
        /// <summary>
        /// 设备领域服务
        /// </summary>
        private readonly IDeviceDomainService deviceDomainService;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<DeviceSynchronizesControlTaskResponseCommandHandler> logger;

        /// <summary>
        /// 实例化设备同步控制任务响应命令处理器
        /// </summary>
        /// <param name="deviceDomainService">设备领域服务</param>
        /// <param name="logger">日志器</param>
        public DeviceSynchronizesControlTaskResponseCommandHandler(IDeviceDomainService deviceDomainService, ILogger<DeviceSynchronizesControlTaskResponseCommandHandler> logger)
        {
            this.deviceDomainService = deviceDomainService;
            this.logger = logger;
        }

        /// <summary>
        /// 异步处理设备同步控制任务响应命令
        /// </summary>
        /// <param name="request">设备同步控制任务响应命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public override async Task Handle(DeviceSynchronizesControlTaskResponseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await deviceDomainService.UpdateDeviceControlTaskAsync(request.DeviceCode, request.Data.TaskId, request.Data.Result, request.Data.Message, request.Data.Response);
            }
            catch (Exception ex)
            {
                logger.LogCritical();
            }
        }
    }
}