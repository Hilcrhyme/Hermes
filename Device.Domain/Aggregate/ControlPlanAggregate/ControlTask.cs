using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.ControlPlanAggregate
{
    /// <summary>
    /// 控制任务
    /// </summary>
    public class ControlTask : Entity
    {
        /// <summary>
        /// 执行控制任务的设备 Id
        /// </summary>
        public long DeviceId { get; private set; } = 0;

        /// <summary>
        /// 控制任务所属控制计划 Id
        /// </summary>
        public long ControlPlanId { get; private set; } = 0;

        /// <summary>
        /// 控制任务状态
        /// </summary>
        public ControlTaskState State { get; private set; } = ControlTaskState.Unknown;

        /// <summary>
        /// 控制任务错误
        /// </summary>
        public ControlTaskError? Error { get; private set; } = null;

        /// <summary>
        /// 设备响应
        /// </summary>
        public string? Response { get; private set; } = null;
    }
}