namespace Hermes.Service.Device.Domain.Aggregate.MqttEventAggregate
{
    /// <summary>
    /// 客户端连接已断开 Mqtt 事件
    /// </summary>
    public class ClientDisconnectedMqttEvent : MqttEvent
    {
        /// <summary>
        /// 客户端连接断开原因
        /// </summary>
        public ClientDisconnectReason Reason { get; init; } = ClientDisconnectReason.Unknown;

        /// <summary>
        /// 连接断开时间
        /// <para>单位为毫秒</para>
        /// </summary>
        public long DisconnectedAt { get; init; } = 0;

        /// <summary>
        /// 实例化客户端连接已断开 Mqtt 事件
        /// </summary>
        /// <param name="id">客户端连接已断开 Mqtt 事件 Id</param>
        public ClientDisconnectedMqttEvent(long id)
        {
            Id = id;
            Type = MqttEventType.ClientDisconnected;
        }
    }
}