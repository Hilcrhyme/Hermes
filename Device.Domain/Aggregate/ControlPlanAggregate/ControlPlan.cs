using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.ControlPlanAggregate
{
    /// <summary>
    /// 控制计划
    /// </summary>
    public class ControlPlan : Entity, IAggregateRoot
    {
        /// <summary>
        /// 控制计划名称
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// 控制计划超时
        /// </summary>
        public TimeSpan Timeout { get; private set; } = TimeSpan.Zero;

        /// <summary>
        /// 控制任务枚举
        /// </summary>
        public virtual IEnumerable<ControlTask> ControlTasks { get; private set; } = Enumerable.Empty<ControlTask>();
    }
}