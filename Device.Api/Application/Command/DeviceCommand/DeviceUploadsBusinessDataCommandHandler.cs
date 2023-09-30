namespace Hermes.Service.Device.Api.Application.Command.DeviceCommand
{
    /// <summary>
    /// 设备上传业务数据命令处理器
    /// </summary>
    public class DeviceUploadsBusinessDataCommandHandler : CommunicationCommandHandler<DeviceUploadsBusinessDataCommand>
    {
        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<DeviceUploadsBusinessDataCommandHandler> logger;

        /// <summary>
        /// 实例化设备上传业务数据命令处理器
        /// </summary>
        /// <param name="logger">日志器</param>
        public DeviceUploadsBusinessDataCommandHandler(ILogger<DeviceUploadsBusinessDataCommandHandler> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// 异步处理设备上传业务数据命令
        /// </summary>
        /// <param name="request">设备上传业务数据命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public override Task Handle(DeviceUploadsBusinessDataCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation();
            return Task.CompletedTask;
        }
    }
}