using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregates.ControlPlanAggregate
{
    /// <summary>
    /// 控制计划
    /// </summary>
    public class ControlPlan : Entity, IAggregateRoot
    {
        /// <summary>
        /// 控制计划名称
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// 控制计划数据
        /// </summary>
        public string Data { get; init; } = string.Empty;

        /// <summary>
        /// 控制计划超时
        /// </summary>
        public TimeSpan Timeout { get; init; } = TimeSpan.Zero;

        /// <summary>
        /// 控制任务列表
        /// </summary>
        private readonly List<ControlTask> controlTasks = new();

        /// <summary>
        /// 控制任务枚举
        /// </summary>
        public virtual IEnumerable<ControlTask> ControlTasks => controlTasks;

        /// <summary>
        /// 实例化控制计划
        /// </summary>
        /// <param name="id">控制计划 Id</param>
        /// <param name="name">控制计划名称</param>
        /// <param name="data">控制计划数据</param>
        /// <param name="timeout">控制计划超时</param>

        public ControlPlan(long id, string name, string data, TimeSpan timeout)
        {
            Id = id;
            Name = name;
            Data = data;
            Timeout = timeout;
        }

        /// <summary>
        /// 添加控制任务
        /// </summary>
        /// <param name="task">控制任务</param>
        public void AddControlTask(ControlTask task)
        {
            controlTasks.Add(task);
        }
    }
}