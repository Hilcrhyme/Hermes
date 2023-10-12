using Hermes.Service.Device.Api.Application.Commands.PlatformCommand;
using Hermes.Service.Device.Api.Application.Query;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands.DeviceCommand
{
    /// <summary>
    /// 设备请求数据命令处理器
    /// </summary>
    public class DeviceRequestsDataCommandHandler : CommunicationCommandHandler<DeviceRequestsDataCommand>
    {
        /// <summary>
        /// 设备查询
        /// </summary>
        private readonly IDeviceQuery deviceQuery;

        /// <summary>
        /// Mqtt 连接查询
        /// </summary>
        private readonly IMqttConnectionQuery mqttConnectionQuery;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<DeviceRequestsDataCommandHandler> logger;

        /// <summary>
        /// 消息中介器
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// 实例化设备请求数据命令处理器
        /// </summary>
        /// <param name="deviceQuery">设备查询</param>
        /// <param name="mqttConnectionQuery">Mqtt 连接查询</param>
        /// <param name="logger">日志器</param>
        /// <param name="mediator">消息中介器</param>
        public DeviceRequestsDataCommandHandler(IDeviceQuery deviceQuery, IMqttConnectionQuery mqttConnectionQuery, ILogger<DeviceRequestsDataCommandHandler> logger, IMediator mediator)
        {
            this.deviceQuery = deviceQuery;
            this.mqttConnectionQuery = mqttConnectionQuery;
            this.logger = logger;
            this.mediator = mediator;
        }

        /// <summary>
        /// 异步处理设备请求数据命令
        /// </summary>
        /// <param name="request">设备请求数据命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public override async Task Handle(DeviceRequestsDataCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dataDictionary = await deviceQuery.GetDataDictionaryByDeviceCodeAsync(request.DeviceCode, request.Data);
                await mediator.Publish(new PlatformRespondsDataCommand(request.DeviceCode, dataDictionary), cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogCritical();
            }
        }
    }
}