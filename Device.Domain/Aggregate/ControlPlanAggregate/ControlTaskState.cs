namespace Hermes.Service.Device.Domain.Aggregate.ControlPlanAggregate
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
        /// 控制任务已完成
        /// </summary>
        Completed = 3
    }
}