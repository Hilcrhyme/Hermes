namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 更新任务
    /// </summary>
    public readonly record struct UpdateTask
    {
        /// <summary>
        /// 更新任务 Id
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// 更新任务名称
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// 更新目标名称
        /// </summary>
        public string TargetName { get; init; }

        /// <summary>
        /// 更新后的版本
        /// </summary>
        public string UpdatedVersion { get; init; }

        /// <summary>
        /// 更新支持的版本集合
        /// </summary>
        public IEnumerable<string> SupportedSoftwareVersions { get; init; }

        /// <summary>
        /// 更新包名称
        /// </summary>
        public string PackageName { get; init; }

        /// <summary>
        /// 更新包统一资源定位符
        /// </summary>
        public string PackageUrl { get; init; }

        /// <summary>
        /// 更新包大小
        /// </summary>
        public long PackageSize { get; init; }

        /// <summary>
        /// 更新包 MD5
        /// </summary>
        public string PackageMD5 { get; init; }

        /// <summary>
        /// 更新进度集合
        /// </summary>
        public IEnumerable<UpdateProgress> UpdateProgresses { get; init; }

        /// <summary>
        /// 任务状态
        /// </summary>
        public string State { get; init; }
    }
}