namespace Hermes.Service.Device.Domain.Aggregate.DeviceAggregate
{
    /// <summary>
    /// Tcp 连接
    /// </summary>
    public class TcpConnection : Connection
    {
        /// <summary>
        /// 终结点
        /// </summary>
        public string EndPoint { get; init; } = string.Empty;

        /// <summary>
        /// 端口
        /// </summary>
        public short Port { get; init; } = 0;

        /// <summary>
        /// 实例化 Tcp 连接
        /// </summary>
        public TcpConnection()
        {
            Type = ConnectionType.Tcp;
        }
    }
}