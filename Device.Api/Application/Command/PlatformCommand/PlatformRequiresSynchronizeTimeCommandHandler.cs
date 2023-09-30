using System.Text.Json;

using Hermes.Service.Device.Api.Application.Query;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Command.PlatformCommand
{
    /// <summary>
    /// 平台要求同步时间命令
    /// </summary>
    public class PlatformRequiresSynchronizeTimeCommandHandler : CommunicationCommandHandler<PlatformRequiresSynchronizeTimeCommand>
    {
        /// <summary>
        /// Mqtt 连接查询
        /// </summary>
        private readonly IMqttConnectionQuery mqttConnectionQuery;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<PlatformRequiresSynchronizeTimeCommandHandler> logger;

        /// <summary>
        /// 消息中介器
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// 实例化平台要求同步时间命令
        /// </summary>
        /// <param name="mqttConnectionQuery">Mqtt 连接查询</param>
        /// <param name="logger">日志器</param>
        /// <param name="mediator">消息中介器</param>
        public PlatformRequiresSynchronizeTimeCommandHandler(IMqttConnectionQuery mqttConnectionQuery, ILogger<PlatformRequiresSynchronizeTimeCommandHandler> logger, IMediator mediator)
        {
            this.mqttConnectionQuery = mqttConnectionQuery;
            this.logger = logger;
            this.mediator = mediator;
        }

        /// <summary>
        /// 异步处理平台要求同步时间命令
        /// </summary>
        /// <param name="request">平台要求同步时间命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public override async Task Handle(PlatformRequiresSynchronizeTimeCommand request, CancellationToken cancellationToken)
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
            catch (Exception ex)
            {
                logger.LogCritical();
            }
        }
    }
}