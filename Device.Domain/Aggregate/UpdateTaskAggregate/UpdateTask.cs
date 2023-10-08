using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.UpdateTaskAggregate
{
    /// <summary>
    /// 更新任务
    /// </summary>
    public class UpdateTask : Entity, IAggregateRoot
    {
        /// <summary>
        /// 更新任务名称
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// 更新目标名称
        /// </summary>
        public string TargetName { get; private set; } = string.Empty;

        /// <summary>
        /// 更新目标类型
        /// </summary>
        public UpdateTargetType TargetType { get; private set; } = UpdateTargetType.Unknown;

        /// <summary>
        /// 更新后的版本
        /// </summary>
        public string UpdatedVersion { get; private set; } = string.Empty;

        /// <summary>
        /// 支持更新的版本枚举
        /// </summary>
        public IEnumerable<string> SupportedVersions { get; private set; } = Enumerable.Empty<string>();

        /// <summary>
        /// 更新包 Id
        /// </summary>
        public long UpdatePackageId { get; private set; } = 0;

        /// <summary>
        /// 更新子任务枚举
        /// </summary>
        public virtual IEnumerable<SubUpdateTask> SubUpdateTasks { get; private set; } = Enumerable.Empty<SubUpdateTask>();
    }
}