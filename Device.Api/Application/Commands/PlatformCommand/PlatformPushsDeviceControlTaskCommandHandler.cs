using System.Text.Json;

using Hermes.Service.Device.Api.Application.Query;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands.PlatformCommand
{
    /// <summary>
    /// 平台推送设备控制任务命令处理器
    /// </summary>
    public class PlatformPushsDeviceControlTaskCommandHandler : CommunicationCommandHandler<PlatformPushsDeviceControlTaskCommand>
    {
        /// <summary>
        /// Mqtt 连接查询
        /// </summary>
        private readonly IMqttConnectionQuery mqttConnectionQuery;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<PlatformPushsDeviceControlTaskCommandHandler> logger;

        /// <summary>
        /// 消息中介器
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// 实例化平台推送设备控制任务命令处理器
        /// </summary>
        /// <param name="mqttConnectionQuery">Mqtt 连接查询</param>
        /// <param name="logger">日志器</param>
        /// <param name="mediator">消息中介器</param>
        public PlatformPushsDeviceControlTaskCommandHandler(IMqttConnectionQuery mqttConnectionQuery, ILogger<PlatformPushsDeviceControlTaskCommandHandler> logger, IMediator mediator)
        {
            this.mqttConnectionQuery = mqttConnectionQuery;
            this.logger = logger;
            this.mediator = mediator;
        }

        /// <summary>
        /// 异步处理平台推送设备控制任务命令
        /// </summary>
        /// <param name="request">平台推送设备控制任务命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public override async Task Handle(PlatformPushsDeviceControlTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var topics = await mqttConnectionQuery.GetNotificationTopicsAsync(request.DeviceCode);
                if (!topics.Any())
                {
                    logger.LogError();
                    return;
                }
                await mediator.Publish(new PublishMqttMessageCommand()
                {
                    Topic = topics.First(),
                    Payload = JsonSerializer.SerializeToUtf8Bytes(request)
                }, cancellationToken);
            }
            catch (Exception)
            {
                logger.LogCritical();
            }
        }
    }
}