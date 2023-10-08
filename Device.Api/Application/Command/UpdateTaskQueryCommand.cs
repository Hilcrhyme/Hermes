using Hermes.Service.Device.Domain.Aggregate.UpdatePlanAggregate;

namespace Hermes.Service.Device.Api.Application.Command
{
    /// <summary>
    /// 更新任务查询命令
    /// </summary>
    public record class UpdateTaskQueryCommand : QueryCommand
    {
        /// <summary>
        /// 执行更新任务的设备 Id
        /// </summary>
        public long? DeviceId { get; init; }

        /// <summary>
        /// 更新任务所属更新计划 Id
        /// </summary>
        public long? UpdatePlanId { get; init; }

        /// <summary>
        /// 更新任务状态
        /// </summary>
        public UpdateTaskState? UpdateTaskState { get; init; }
    }
}