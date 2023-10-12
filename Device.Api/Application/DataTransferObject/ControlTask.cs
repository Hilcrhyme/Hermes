using Hermes.Service.Device.Domain.Aggregates.ControlPlanAggregate;

namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 控制任务
    /// </summary>
    public readonly record struct ControlTask
    {
        /// <summary>
        /// 执行控制任务的设备 Id
        /// </summary>
        public long DeviceId { get; init; }

        /// <summary>
        /// 控制任务所属控制计划 Id
        /// </summary>
        public long ControlPlanId { get; init; }

        /// <summary>
        /// 控制任务状态
        /// </summary>
        public ControlTaskState State { get; init; }

        /// <summary>
        /// 设备响应
        /// </summary>
        public string? Response { get; init; }
    }
}