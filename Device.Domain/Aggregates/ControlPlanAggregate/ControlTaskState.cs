namespace Hermes.Service.Device.Domain.Aggregates.ControlPlanAggregate
{
    /// <summary>
    /// 控制任务状态
    /// </summary>
    public enum ControlTaskState
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 控制任务已创建
        /// </summary>
        Created = 1,

        /// <summary>
        /// 控制任务已推送
        /// </summary>
        Pushed = 2,

        /// <summary>
        /// 控制任务推送超时
        /// </summary>
        PushTimeout = 3,

        /// <summary>
        /// 控制任务执行中
        /// </summary>
        Executing = 4,

        /// <summary>
        /// 控制任务执行超时
        /// </summary>
        ExecutionTimeout = 5,

        /// <summary>
        /// 控制任务已完成
        /// </summary>
        Completed = 6,

        /// <summary>
        /// 控制任务已取消
        /// </summary>
        Cancelled = 7
    }
}