namespace Hermes.Service.Device.Domain.Aggregates.MqttEventAggregate
{
    /// <summary>
    /// 消息已发布 Mqtt 事件
    /// </summary>
    public class MessagePublishedMqttEvent : MqttEvent
    {
        /// <summary>
        /// 消息 Id
        /// </summary>
        public string MessageId { get; init; } = string.Empty;

        /// <summary>
        /// 消息负载
        /// </summary>
        public string Payload { get; init; } = string.Empty;

        /// <summary>
        /// 消息主题
        /// </summary>
        public string Topic { get; init; } = string.Empty;

        /// <summary>
        /// 服务质量
        /// </summary>
        public QualityofService QualityofService { get; init; } = QualityofService.AtMostOnce;

        /// <summary>
        /// 保留消息标志
        /// </summary>
        public bool RetainFlag { get; init; } = false;

        /// <summary>
        /// 重复消息标志
        /// </summary>
        public bool DupFlag { get; init; } = false;

        /// <summary>
        /// 消息到达 Broker 的时间
        /// <para>单位为毫秒</para>
        /// </summary>
        public long PublishReceivedAt { get; init; } = 0;

        /// <summary>
        /// 实例化消息已发布 Mqtt 事件
        /// </summary>
        /// <param name="id">消息已发布 Mqtt 事件 Id</param>
        public MessagePublishedMqttEvent(long id)
        {
            Id = id;
            Type = MqttEventType.MessagePublished;
        }
    }
}