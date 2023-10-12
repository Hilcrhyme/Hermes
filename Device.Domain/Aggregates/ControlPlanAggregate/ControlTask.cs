using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregates.ControlPlanAggregate
{
    /// <summary>
    /// 控制任务
    /// </summary>
    public class ControlTask : Entity
    {
        /// <summary>
        /// 执行控制任务的设备 Id
        /// </summary>
        public long DeviceId { get; init; } = 0;

        /// <summary>
        /// 控制任务所属控制计划 Id
        /// </summary>
        public long ControlPlanId { get; init; } = 0;

        /// <summary>
        /// 控制任务状态
        /// </summary>
        public ControlTaskState State { get; private set; } = ControlTaskState.Unknown;

        /// <summary>
        /// 设备响应
        /// </summary>
        public string? Response { get; private set; } = null;

        /// <summary>
        /// 实例化控制任务
        /// </summary>
        /// <param name="id">控制任务 Id</param>
        /// <param name="deviceId">执行控制任务的设备 Id</param>
        /// <param name="controlPlanId">控制任务所属控制计划 Id</param>
        public ControlTask(long id, long deviceId, long controlPlanId)
        {
            Id = id;
            DeviceId = deviceId;
            ControlPlanId = controlPlanId;
        }
    }
}