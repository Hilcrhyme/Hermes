using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.DeviceAggregate
{
    /// <summary>
    /// 软件更新任务
    /// </summary>
    public class SoftwareUpdateTask : Entity
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 软件名称
        /// </summary>
        public string SoftwareName { get; set; } = string.Empty;

        /// <summary>
        /// 更新后的版本
        /// </summary>
        public string UpdatedVersion { get; set; } = string.Empty;

        /// <summary>
        /// 更新支持的版本集合
        /// </summary>
        public virtual ICollection<string> SupportedSoftwareVersions { get; set; } = Array.Empty<string>();

        /// <summary>
        /// 更新包名称
        /// </summary>
        public string PackageName { get; init; } = string.Empty;

        /// <summary>
        /// 更新包统一资源定位符
        /// </summary>
        public string PackageUrl { get; set; } = string.Empty;

        /// <summary>
        /// 更新包大小
        /// </summary>
        public long PackageSize { get; set; } = 0;

        /// <summary>
        /// 更新包 MD5
        /// </summary>
        public string PackageMD5 { get; set; } = string.Empty;

        /// <summary>
        /// 更新进度集合
        /// </summary>
        public virtual ICollection<SoftwareUpdateTaskProgress> UpdateProgresses { get; set; } = Array.Empty<SoftwareUpdateTaskProgress>();

        /// <summary>
        /// 任务状态
        /// </summary>
        public SoftwareUpdateTaskState State { get; set; } = SoftwareUpdateTaskState.Unknown;
    }
}