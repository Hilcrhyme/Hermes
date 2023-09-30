namespace Hermes.Service.Device.Domain.Aggregate.DeviceAggregate
{
    /// <summary>
    /// 软件更新任务状态
    /// </summary>
    public enum SoftwareUpdateTaskState
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 任务未开始
        /// </summary>
        NotStarted = 1,

        /// <summary>
        /// 任务推送中
        /// </summary>
        Pushing = 2,

        /// <summary>
        /// 任务更新中
        /// </summary>
        Updating = 3,

        /// <summary>
        /// 任务完成
        /// </summary>
        Done = 4
    }
}