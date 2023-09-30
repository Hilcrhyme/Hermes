namespace Hermes.Service.Device.Domain.Aggregate.DeviceAggregate
{
    /// <summary>
    /// 设备类型
    /// </summary>
    public enum DeviceType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 网关
        /// </summary>
        Gateway = 1,

        /// <summary>
        /// 中继
        /// </summary>
        Repeater = 2,

        /// <summary>
        /// 节点
        /// </summary>
        Node = 3
    }
}