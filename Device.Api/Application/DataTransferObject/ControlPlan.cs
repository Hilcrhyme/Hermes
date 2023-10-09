namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 控制计划
    /// </summary>
    public readonly record struct ControlPlan
    {
        /// <summary>
        /// 控制计划 Id
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// 控制计划名称
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// 控制计划数据
        /// </summary>
        public string Data { get; init; }

        /// <summary>
        /// 控制计划超时
        /// </summary>
        public TimeSpan Timeout { get; init; }

        /// <summary>
        /// 控制任务枚举
        /// </summary>
        public IEnumerable<ControlTask> ControlTasks { get; init; }
    }
}