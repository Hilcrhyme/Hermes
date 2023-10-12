using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregates.UpdatePackageAggregate
{
    /// <summary>
    /// 更新包
    /// </summary>
    public class UpdatePackage : Entity, IAggregateRoot
    {
        /// <summary>
        /// 更新包名称
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// 更新后的版本
        /// </summary>
        public string UpdatedVersion { get; private set; } = string.Empty;

        /// <summary>
        /// 支持更新的版本枚举
        /// <para>为空枚举代表所有版本均可使用该更新包</para>
        /// </summary>
        public IEnumerable<string> SupportedVersions { get; private set; } = Enumerable.Empty<string>();

        /// <summary>
        /// 更新包路径
        /// </summary>
        public string Path { get; private set; } = string.Empty;

        /// <summary>
        /// 更新包大小
        /// </summary>
        public long Size { get; private set; } = 0;

        /// <summary>
        /// 文件 MD5
        /// </summary>
        public string MD5 { get; private set; } = string.Empty;

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime UploadedTime { get; private set; } = DateTime.MinValue;
    }
}