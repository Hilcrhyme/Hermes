using Hermes.Service.Device.Domain.Aggregate.UpdatePlanAggregate;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 更新计划查询请求
    /// </summary>
    public record class UpdatePlanQueryRequest : QueryRequest
    {
        /// <summary>
        /// 更新计划 Id
        /// </summary>
        public long? UpdatePlanId { get; init; } = default;

        /// <summary>
        /// 更新计划名称
        /// </summary>
        public string? UpdatePlanName { get; init; } = default;

        /// <summary>
        /// 更新目标类型
        /// </summary>
        public UpdateTargetType? UpdateTargetType { get; init; } = default;
    }
}