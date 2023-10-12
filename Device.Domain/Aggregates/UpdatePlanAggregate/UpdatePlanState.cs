namespace Hermes.Service.Device.Domain.Aggregates.UpdatePlanAggregate
{
    /// <summary>
    /// 更新计划状态
    /// </summary>
    public enum UpdatePlanState
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 更新计划待执行
        /// </summary>
        Pending = 1,
        
        /// <summary>
        /// 更新计划执行中
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// 更新计划已完成
        /// </summary>
        Completed = 3,

        /// <summary>
        /// 更新计划已取消
        /// </summary>
        Cancelled = 4
    }
}