using Hermes.Service.Device.Domain.Aggregates.UpdatePackageAggregate;
using Hermes.Service.Device.Domain.Aggregates.UpdatePlanAggregate;

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
        /// 更新包类型
        /// </summary>
        public UpdatePackageType? UpdatePackageType { get; init; } = default;
    }
}