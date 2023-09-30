namespace Hermes.Service.Device.Api.Application.DataTransferObject.EmqxEvent
{
    /// <summary>
    /// Emqx 消息已发布事件
    /// </summary>
    public record EmqxMessagePublishedEvent : EmqxEvent
    {
        /// <summary>
        /// 消息 Id
        /// </summary>
        public string MessageId { get; init; } = string.Empty;

        /// <summary>
        /// 主题
        /// </summary>
        public string Topic { get; init; } = string.Empty;

        /// <summary>
        /// 有效负荷
        /// </summary>
        public string Payload { get; init; } = string.Empty;

        /// <summary>
        /// 服务质量
        /// </summary>
        public byte QualityOfService { get; init; } = 0;

        /// <summary>
        /// 保留消息标志
        /// </summary>
        public bool RetainFlag { get; init; } = false;

        /// <summary>
        /// 重复消息标志
        /// </summary>
        public bool DupFlag { get; init; } = false;

        /// <summary>
        /// 消息到达 Mqtt Broker 的时间
        /// <para>单位为毫秒</para>
        /// </summary>
        public long PublishReceivedAt { get; init; } = 0;
    }
}