namespace Hermes.Service.Device.Domain.Aggregates.MqttEventAggregate
{
    /// <summary>
    /// 客户端已连接 Mqtt 事件
    /// </summary>
    public class ClientConnectedMqttEvent : MqttEvent
    {
        /// <summary>
        /// 连接完成时间
        /// <para>单位为毫秒</para>
        /// </summary>
        public long ConnectedAt { get; init; } = 0;

        /// <summary>
        /// 实例化客户端已连接 Mqtt 事件
        /// </summary>
        /// <param name="id">客户端已连接 Mqtt 事件 Id</param>
        public ClientConnectedMqttEvent(long id)
        {
            Id = id;
            Type = MqttEventType.ClientConnected;
        }
    }
}