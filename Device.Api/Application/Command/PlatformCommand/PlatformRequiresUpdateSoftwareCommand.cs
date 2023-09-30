using System.Text.Json.Serialization;

namespace Hermes.Service.Device.Api.Application.Command.PlatformCommand
{
    /// <summary>
    /// 平台要求更新软件命令
    /// </summary>
    public class PlatformRequiresUpdateSoftwareCommand : CommunicationCommand<SoftwareUpdateTask>
    {
        /// <summary>
        /// 实例化平台要求更新软件命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">软件更新通知</param>
        public PlatformRequiresUpdateSoftwareCommand(string deviceCode, SoftwareUpdateTask data) : base(deviceCode, data)
        {
            Type = PlatformRequiresUpdateSoftwareCommandType;
        }
    }

    /// <summary>
    /// 软件更新任务
    /// </summary>
    public record class SoftwareUpdateTask
    {
        /// <summary>
        /// 任务 Id
        /// </summary>
        [JsonPropertyName("tid")]
        public long TaskId { get; init; } = 0;

        /// <summary>
        /// 软件名称
        /// </summary>
        [JsonPropertyName("sn")]
        public string SoftwareName { get; init; } = string.Empty;

        /// <summary>
        /// 软件版本
        /// </summary>
        [JsonPropertyName("sv")]
        public string SoftwareVersion { get; init; } = string.Empty;

        /// <summary>
        /// 更新包名称
        /// </summary>
        [JsonPropertyName("pn")]
        public string PackageName { get; init; } = string.Empty;

        /// <summary>
        /// 更新包统一资源定位符
        /// </summary>
        [JsonPropertyName("pu")]
        public string PackageUrl { get; init; } = string.Empty;

        /// <summary>
        /// 更新包大小
        /// </summary>
        [JsonPropertyName("ps")]
        public long PackageSize { get; init; } = 0;

        /// <summary>
        /// 更新包 MD5
        /// </summary>
        [JsonPropertyName("md5")]
        public string PackageMD5 { get; init; } = string.Empty;
    }
}