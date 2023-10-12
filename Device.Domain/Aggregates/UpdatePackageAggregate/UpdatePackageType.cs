namespace Hermes.Service.Device.Domain.Aggregates.UpdatePackageAggregate
{
    /// <summary>
    /// 更新包类型
    /// </summary>
    public enum UpdatePackageType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 软件更新包
        /// </summary>
        Software = 1,

        /// <summary>
        /// 硬件更新包
        /// </summary>
        Hardware = 2
    }
}