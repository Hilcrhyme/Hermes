namespace Hermes.Service.Device.Domain.Aggregate.DeviceAggregate
{
    /// <summary>
    /// 连接类型
    /// </summary>
    public enum ConnectionType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Tcp 连接
        /// </summary>
        Tcp = 1,

        /// <summary>
        /// Mqtt 连接
        /// </summary>
        Mqtt = 2
    }
}