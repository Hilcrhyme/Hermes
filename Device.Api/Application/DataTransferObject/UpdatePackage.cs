namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 更新包
    /// </summary>
    public readonly record struct UpdatePackage
    {
        /// <summary>
        /// 更新包 Id
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// 更新包名称
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// 更新包版本
        /// </summary>
        public string Version { get; init; }

        /// <summary>
        /// 更新包路径
        /// </summary>
        public string Path { get; init; }

        /// <summary>
        /// 更新包大小
        /// </summary>
        public long Size { get; init; }

        /// <summary>
        /// 文件 MD5
        /// </summary>
        public string MD5 { get; init; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime UploadedTime { get; init; }
    }
}