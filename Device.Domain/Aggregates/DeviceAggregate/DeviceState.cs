namespace Hermes.Service.Device.Domain.Aggregates.DeviceAggregate
{
    /// <summary>
    /// 设备状态
    /// </summary>
    public enum DeviceState
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 测试中
        /// </summary>
        Testing = 1,

        /// <summary>
        /// 使用中
        /// </summary>
        Using = 2,

        /// <summary>
        /// 库存中
        /// </summary>
        Storing = 3,

        /// <summary>
        /// 机修中
        /// </summary>
        Repairing
    }
}