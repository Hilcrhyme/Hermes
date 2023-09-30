namespace Hermes.Service.Device.Domain.Aggregate.DeviceAggregate
{
    /// <summary>
    /// Mqtt 连接
    /// </summary>
    public class MqttConnection : TcpConnection
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
        /// 用户密码
        /// </summary>
        public string Password { get; init; } = string.Empty;

        /// <summary>
        /// 上行链路主题
        /// </summary>
        public string UplinkTopic { get; init; } = string.Empty;

        /// <summary>
        /// 下行链路主题
        /// </summary>
        public string DownlinkTopic { get; init; } = string.Empty;

        /// <summary>
        /// 通知主题
        /// </summary>
        public string NotificationTopic { get; init; } = string.Empty;

        /// <summary>
        /// 同步主题
        /// </summary>
        public string SynchronizationTopic { get; init; } = string.Empty;

        /// <summary>
        /// 实例化 Mqtt 连接
        /// </summary>
        public MqttConnection()
        {
            Type = ConnectionType.Mqtt;
        }
    }
}