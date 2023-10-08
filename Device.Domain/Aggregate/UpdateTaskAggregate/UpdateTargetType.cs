namespace Hermes.Service.Device.Domain.Aggregate.UpdateTaskAggregate
{
    /// <summary>
    /// 更新目标类型
    /// </summary>
    public enum UpdateTargetType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 软件
        /// </summary>
        Software = 1,

        /// <summary>
        /// 硬件
        /// </summary>
        Hardware = 2
    }
}