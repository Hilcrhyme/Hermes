using Hermes.Service.Device.Domain.Aggregate.UpdatePlanAggregate;

namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 更新计划
    /// </summary>
    public readonly record struct UpdatePlan
    {
        /// <summary>
        /// 更新计划 Id
        /// </summary>
        public long UpdatePlanId { get; init; }

        /// <summary>
        /// 更新计划名称
        /// </summary>
        public string UpdatePlanName { get; init; }

        /// <summary>
        /// 更新目标名称
        /// </summary>
        public string TargetName { get; init; }

        /// <summary>
        /// 更新目标类型
        /// </summary>
        public UpdateTargetType TargetType { get; init; }

        /// <summary>
        /// 更新后的版本
        /// </summary>
        public string UpdatedVersion { get; init; }

        /// <summary>
        /// 支持更新的版本枚举
        /// </summary>
        public IEnumerable<string> SupportedVersions { get; init; }

        /// <summary>
        /// 更新包 Id
        /// </summary>
        public long UpdatePackageId { get; init; }

        /// <summary>
        /// 更新任务枚举
        /// </summary>
        public IEnumerable<UpdateTask> UpdateTasks { get; init; }
    }
}