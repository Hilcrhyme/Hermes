using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregates.MqttEventAggregate
{
    /// <summary>
    /// Mqtt 事件
    /// </summary>
    public abstract class MqttEvent : Entity, IAggregateRoot
    {
        /// <summary>
        /// 客户端 Id
        /// </summary>
        public string ClientId { get; init; } = string.Empty;

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Username { get; init; } = string.Empty;

        /// <summary>
        /// 事件触发时间
        /// <para>单位为毫秒</para>
        /// </summary>
        public long Timestamp { get; init; } = 0;

        /// <summary>
        /// Mqtt 事件类型
        /// </summary>
        public MqttEventType Type { get; protected init; } = MqttEventType.Unknown;
    }
}