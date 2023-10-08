using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.UpdatePackageAggregate
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
        /// 更新包版本
        /// </summary>
        public string Version { get; private set; } = string.Empty;

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