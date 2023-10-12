using Hermes.Service.Device.Domain.Aggregates.ControlPlanAggregate;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 控制任务查询请求
    /// </summary>
    public record class ControlTaskQueryRequest : QueryRequest
    {
        /// <summary>
        /// 控制任务 Id
        /// </summary>
        public long? ControlTaskId { get; init; } = null;

        /// <summary>
        /// 控制任务所属控制计划 Id
        /// </summary>
        public long? ControlPlanId { get; init; } = null;

        /// <summary>
        /// 控制任务状态
        /// </summary>
        public ControlTaskState? State { get; init; } = null;
    }
}