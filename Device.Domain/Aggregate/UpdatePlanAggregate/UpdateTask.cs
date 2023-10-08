using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.UpdatePlanAggregate
{
    /// <summary>
    /// 更新任务
    /// </summary>
    public class UpdateTask : Entity
    {
        /// <summary>
        /// 执行更新任务的设备 Id
        /// </summary>
        public long DeviceId { get; private set; } = 0;

        /// <summary>
        /// 更新任务所属更新计划 Id
        /// </summary>
        public long UpdatePlanId { get; private set; } = 0;

        /// <summary>
        /// 更新任务状态
        /// </summary>
        public UpdateTaskState State { get; private set; } = UpdateTaskState.Unknown;

        /// <summary>
        /// 更新任务进度枚举
        /// </summary>
        public IEnumerable<UpdateTaskProgress> Progresses { get; private set; } = Enumerable.Empty<UpdateTaskProgress>();
    }
}