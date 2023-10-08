using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.UpdateTaskAggregate
{
    /// <summary>
    /// 更新子任务
    /// </summary>
    public class SubUpdateTask : Entity
    {
        /// <summary>
        /// 执行更新子任务的设备 Id
        /// </summary>
        public long DeviceId { get; private set; } = 0;

        /// <summary>
        /// 所属更新任务的 Id
        /// </summary>
        public long UpdateTaskId { get; private set; } = 0;

        /// <summary>
        /// 更新子任务状态
        /// </summary>
        public SubUpdateTaskState State { get; private set; } = SubUpdateTaskState.Unknown;

        /// <summary>
        /// 更新子任务进度枚举
        /// </summary>
        public IEnumerable<SubUpdateTaskProgress> Progresses { get; private set; } = Enumerable.Empty<SubUpdateTaskProgress>();
    }
}