using System.Text.Json;

using Hermes.Common.Extension;
using Hermes.Common.IdentityGenerator;
using Hermes.Service.Device.Api.Application.Command.DeviceCommand;
using Hermes.Service.Device.Api.Application.Command.PlatformCommand;
using Hermes.Service.Device.Domain.Aggregate.MqttEventAggregate;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Command
{
    /// <summary>
    /// 创建消息已发布 Mqtt 事件命令处理器
    /// </summary>
    public class CreateMessagePublishedMqttEventCommandHandler : IRequestHandler<CreateMessagePublishedMqttEventCommand>
    {
        /// <summary>
        /// Id 生成器
        /// </summary>
        private readonly IIdentityGenerator<long> identityGenerator;

        /// <summary>
        /// 消息已发布 Mqtt 事件仓储
        /// </summary>
        private readonly IMqttEventRepository<MessagePublishedMqttEvent> mqttEventRepository;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<CreateMessagePublishedMqttEventCommandHandler> logger;

        /// <summary>
        /// 消息中介器
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// 服务器时差容忍
        /// <para>单位为毫秒</para>
        /// </summary>
        private readonly long serverTimeDifferenceTolerance;

        /// <summary>
        /// 实例化创建消息已发布 Mqtt 事件命令处理器
        /// </summary>
        /// <param name="identityGenerator">Id 生成器</param>
        /// <param name="mqttEventRepository">消息已发布 Mqtt 事件仓储</param>
        /// <param name="logger">日志器</param>
        /// <param name="mediator">消息中介器</param>
        /// <param name="serverTimeDifferenceTolerance">
        /// 服务器时差容忍
        /// <para>单位为毫秒</para>
        /// </param>
        public CreateMessagePublishedMqttEventCommandHandler(IIdentityGenerator<long> identityGenerator, IMqttEventRepository<MessagePublishedMqttEvent> mqttEventRepository, ILogger<CreateMessagePublishedMqttEventCommandHandler> logger, IMediator mediator, long serverTimeDifferenceTolerance)
        {
            this.identityGenerator = identityGenerator;
            this.mqttEventRepository = mqttEventRepository;
            this.logger = logger;
            this.mediator = mediator;
            this.serverTimeDifferenceTolerance = serverTimeDifferenceTolerance;
        }

        /// <summary>
        /// 处理命令
        /// </summary>
        /// <param name="request">创建消息已发布 Mqtt 事件命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public async Task Handle(CreateMessagePublishedMqttEventCommand request, CancellationToken cancellationToken)
        {
            var id = await identityGenerator.GetNextIdAsync();
            await mqttEventRepository.AddAsync(new MessagePublishedMqttEvent(id)
            {
                ClientId = request.EmqxMessagePublishedEvent.ClientId,
                Username = request.EmqxMessagePublishedEvent.Username,
                Timestamp = request.EmqxMessagePublishedEvent.Timestamp,
                MessageId = request.EmqxMessagePublishedEvent.MessageId,
                Payload = request.EmqxMessagePublishedEvent.Payload,
                Topic = request.EmqxMessagePublishedEvent.Topic,
                QualityofService = request.EmqxMessagePublishedEvent.QualityOfService switch
                {
                    0 => QualityofService.AtMostOnce,
                    1 => QualityofService.AtLeastOnce,
                    2 => QualityofService.ExactlyOnce,
                    _ => QualityofService.AtMostOnce
                },
                RetainFlag = request.EmqxMessagePublishedEvent.RetainFlag,
                DupFlag = request.EmqxMessagePublishedEvent.DupFlag,
                PublishReceivedAt = request.EmqxMessagePublishedEvent.PublishReceivedAt
            });
            using var document = JsonDocument.Parse(request.EmqxMessagePublishedEvent.Payload);
            if (!document.RootElement.TryGetProperty("dc", out var deviceCodeJsonElement) || deviceCodeJsonElement.ValueKind == JsonValueKind.Null)
            {
                logger.LogError();
                return;
            }
            if (!document.RootElement.TryGetProperty("type", out var typeJsonElement) || typeJsonElement.ValueKind == JsonValueKind.Null)
            {
                logger.LogError();
                return;
            }
            if (!document.RootElement.TryGetProperty("data", out var dataJsonElement) || dataJsonElement.ValueKind == JsonValueKind.Null)
            {
                logger.LogError();
                return;
            }
            if (!document.RootElement.TryGetProperty("ts", out var timestampJsonElement) || !timestampJsonElement.TryGetInt64(out var timestamp))
            {
                logger.LogError();
                return;
            }
            switch (typeJsonElement.GetString())
            {
                case "business-message":
                    await mediator.Publish(new DeviceUploadsBusinessDataCommand(deviceCodeJsonElement.GetString()!, dataJsonElement.Deserialize<BusinessData>()!, timestamp), cancellationToken);
                    break;

                case "control-task-response":
                    await mediator.Publish(new DeviceSynchronizesControlTaskResponseCommand(deviceCodeJsonElement.GetString()!, dataJsonElement.Deserialize<DeviceControlTaskResponse>()!, timestamp), cancellationToken);
                    break;

                case "get-data":
                    await mediator.Publish(new DeviceRequestsDataCommand(deviceCodeJsonElement.GetString()!, dataJsonElement.Deserialize<string[]>()!, timestamp), cancellationToken);
                    break;

                case "logs":
                    await mediator.Publish(new DeviceSynchronizesLogCommand(deviceCodeJsonElement.GetString()!, dataJsonElement.Deserialize<DeviceLog[]>()!, timestamp), cancellationToken);
                    break;

                case "snapshot":
                    await mediator.Publish(new DeviceSynchronizesSnapshotCommand(deviceCodeJsonElement.GetString()!, dataJsonElement.Deserialize<DeviceSnapshot>()!, timestamp), cancellationToken);
                    break;

                case "software-update-progress":
                    await mediator.Publish(new DeviceSynchronizeUpdateProgressCommand(deviceCodeJsonElement.GetString()!, dataJsonElement.Deserialize<UpdateProgress>()!, timestamp), cancellationToken);
                    break;

                default:
                    throw new NotSupportedException();
            }
            if (timestamp == 0)
            {
                // 不要求没有时间的设备进行时间同步
                return;
            }
            if (Math.Abs(DateTime.UtcNow.ToUnixTimeMilliseconds() - timestamp) > serverTimeDifferenceTolerance)
            {
                // 设备时间距离服务器时间太久，要求设备进行时间同步
                await mediator.Publish(new PlatformRequiresSynchronizeTimeCommand(deviceCodeJsonElement.GetString()!), cancellationToken);
            }
        }
    }
}