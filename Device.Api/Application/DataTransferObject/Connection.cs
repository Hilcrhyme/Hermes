using Hermes.Service.Device.Domain.Aggregates.DeviceAggregate;

namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 连接
    /// </summary>
    public readonly record struct Connection
    {
        /// <summary>
        /// 设备 Id
        /// </summary>
        public long DeviceId { get; init; }

        /// <summary>
        /// 设备代码
        /// </summary>
        public string DeviceCode { get; init; }

        /// <summary>
        /// 连接类型
        /// </summary>
        public ConnectionType Type { get; init; }

        /// <summary>
        /// 是否已连接
        /// </summary>
        public bool IsConnected { get; init; }
    }
}