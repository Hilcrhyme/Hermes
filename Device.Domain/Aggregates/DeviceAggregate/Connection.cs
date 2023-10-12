using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregates.DeviceAggregate
{
    /// <summary>
    /// 连接
    /// </summary>
    public abstract class Connection : Entity
    {
        /// <summary>
        /// 设备 Id
        /// </summary>
        public long DeviceId { get; set; } = 0;

        /// <summary>
        /// 设备代码
        /// </summary>
        public string DeviceCode { get; set; } = string.Empty;

        /// <summary>
        /// 连接类型
        /// </summary>
        public ConnectionType Type { get; protected init; } = ConnectionType.Unknown;

        /// <summary>
        /// 是否已连接
        /// </summary>
        public bool IsConnected { get; set; } = false;
    }
}