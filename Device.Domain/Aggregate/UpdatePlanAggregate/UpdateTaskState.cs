namespace Hermes.Service.Device.Domain.Aggregate.UpdatePlanAggregate
{
    /// <summary>
    /// 更新任务状态
    /// </summary>
    public enum UpdateTaskState
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 任务待处理
        /// </summary>
        Pending = 1,

        /// <summary>
        /// 任务推送中
        /// </summary>
        Pushing = 2,

        /// <summary>
        /// 任务进行中
        /// </summary>
        InProgress = 3,

        /// <summary>
        /// 任务已完成
        /// </summary>
        Completed = 4,

        /// <summary>
        /// 任务已失败
        /// </summary>
        Failed = 5
    }
}