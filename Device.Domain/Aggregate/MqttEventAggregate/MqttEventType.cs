namespace Hermes.Service.Device.Domain.Aggregate.MqttEventAggregate
{
    /// <summary>
    /// Mqtt 事件类型
    /// </summary>
    public enum MqttEventType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 客户端已连接
        /// </summary>
        ClientConnected = 1,

        /// <summary>
        /// 客户端连接已断开
        /// </summary>
        ClientDisconnected = 2,

        /// <summary>
        /// 消息已发布
        /// </summary>
        MessagePublished = 3
    }
}