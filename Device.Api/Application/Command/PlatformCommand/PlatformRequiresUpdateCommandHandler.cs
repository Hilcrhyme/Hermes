using System.Text.Json;

using Hermes.Service.Device.Api.Application.Query;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Command.PlatformCommand
{
    /// <summary>
    /// 平台要求更新命令处理器
    /// </summary>
    public class PlatformRequiresUpdateCommandHandler : CommunicationCommandHandler<PlatformRequiresUpdateCommand>
    {
        /// <summary>
        /// Mqtt 连接查询
        /// </summary>
        private readonly IMqttConnectionQuery mqttConnectionQuery;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<PlatformRequiresUpdateCommandHandler> logger;

        /// <summary>
        /// 消息中介器
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// 实例化平台要求更新命令处理器
        /// </summary>
        /// <param name="mqttConnectionQuery">Mqtt 连接查询</param>
        /// <param name="logger">日志器</param>
        /// <param name="mediator">消息中介器</param>
        public PlatformRequiresUpdateCommandHandler(IMqttConnectionQuery mqttConnectionQuery, ILogger<PlatformRequiresUpdateCommandHandler> logger, IMediator mediator)
        {
            this.mqttConnectionQuery = mqttConnectionQuery;
            this.logger = logger;
            this.mediator = mediator;
        }

        /// <summary>
        /// 异步处理平台要求更新命令
        /// </summary>
        /// <param name="request">平台要求更新命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public override async Task Handle(PlatformRequiresUpdateCommand request, CancellationToken cancellationToken)
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
                    Payload = JsonSerializer.SerializeToUtf8Bytes(request),
                    RetainFlag = true
                }, cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogCritical();
            }
        }
    }
}