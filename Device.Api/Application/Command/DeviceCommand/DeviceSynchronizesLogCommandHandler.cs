using Hermes.Service.Device.Domain.Aggregate.DeviceAggregate;

namespace Hermes.Service.Device.Api.Application.Command.DeviceCommand
{
    /// <summary>
    /// 设备同步日志命令处理器
    /// </summary>
    public class DeviceSynchronizesLogCommandHandler : CommunicationCommandHandler<DeviceSynchronizesLogCommand>
    {
        /// <summary>
        /// 设备领域服务
        /// </summary>
        private readonly IDeviceDomainService deviceDomainService;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<DeviceSynchronizesLogCommandHandler> logger;

        /// <summary>
        /// 实例化设备同步日志命令处理器
        /// </summary>
        /// <param name="deviceDomainService">设备领域服务</param>
        /// <param name="logger">日志器</param>
        public DeviceSynchronizesLogCommandHandler(IDeviceDomainService deviceDomainService, ILogger<DeviceSynchronizesLogCommandHandler> logger)
        {
            this.deviceDomainService = deviceDomainService;
            this.logger = logger;
        }

        /// <summary>
        /// 异步处理设备同步日志命令
        /// </summary>
        /// <param name="request">设备同步日志命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public override async Task Handle(DeviceSynchronizesLogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await deviceDomainService.AddDeviceLogsAsync(request.DeviceCode, request.Data.Select(log => new Domain.Aggregate.DeviceAggregate.DeviceLog()
                {
                    GroupName = log.GroupName,
                    Content = log.Content,
                    LogLevel = log.LogLevel,
                    Timestamp = log.Timestamp
                }));
            }
            catch (Exception ex)
            {
                logger.LogCritical();
            }
        }
    }
}