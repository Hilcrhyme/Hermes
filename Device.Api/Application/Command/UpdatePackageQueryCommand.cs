namespace Hermes.Service.Device.Api.Application.Command
{
    /// <summary>
    /// 更新包查询命令
    /// </summary>
    public record class UpdatePackageQueryCommand : QueryCommand
    {
        /// <summary>
        /// 更新包 Id
        /// </summary>
        public long? UpdatePackageId { get; init; } = 0;

        /// <summary>
        /// 更新包名称
        /// </summary>
        public string? UpdatePackageName { get; init; } = string.Empty;

        /// <summary>
        /// 更新包版本
        /// </summary>
        public string? UpdatePackageVersion { get; init; } = string.Empty;

        /// <summary>
        /// 更新包 MD5
        /// </summary>
        public string? UpdatePackageMD5 { get; init; } = string.Empty;
    }
}