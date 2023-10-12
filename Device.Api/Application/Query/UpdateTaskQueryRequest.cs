using Hermes.Service.Device.Domain.Aggregates.UpdatePackageAggregate;
using Hermes.Service.Device.Domain.Aggregates.UpdatePlanAggregate;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 更新任务查询请求
    /// </summary>
    public record class UpdateTaskQueryRequest : QueryRequest
    {
        /// <summary>
        /// 设备 Id
        /// </summary>
        public long? DeviceId { get; init; } = null;

        /// <summary>
        /// 执行更新任务的设备代码
        /// </summary>
        public string? DeviceCode { get; init; } = default;

        /// <summary>
        /// 更新任务所属更新计划 Id
        /// </summary>
        public long? UpdatePlanId { get; init; } = default;

        /// <summary>
        /// 更新包类型
        /// </summary>
        public UpdatePackageType? UpdatePackageType { get; init; } = default;

        /// <summary>
        /// 更新任务状态
        /// </summary>
        public UpdateTaskState? UpdateTaskState { get; init; } = default;
    }
}