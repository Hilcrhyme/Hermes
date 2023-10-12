using System.Text.Json.Serialization;

namespace Hermes.Service.Device.Api.Application.Commands.PlatformCommand
{
    /// <summary>
    /// 平台要求更新命令
    /// </summary>
    public class PlatformRequiresUpdateCommand : CommunicationCommand<UpdateTask>
    {
        /// <summary>
        /// 实例化平台要求更新命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">更新任务</param>
        public PlatformRequiresUpdateCommand(string deviceCode, UpdateTask data) : base(deviceCode, data)
        {
            Type = PlatformRequiresUpdateCommandType;
        }
    }

    /// <summary>
    /// 更新任务
    /// </summary>
    public readonly record struct UpdateTask
    {
        /// <summary>
        /// 更新任务 Id
        /// </summary>
        [JsonPropertyName("tid")]
        public long Id { get; init; }

        /// <summary>
        /// 更新目标名称
        /// </summary>
        [JsonPropertyName("tn")]
        public string TargetName { get; init; }

        /// <summary>
        /// 版本
        /// </summary>
        [JsonPropertyName("v")]
        public string Version { get; init; }

        /// <summary>
        /// 更新包名称
        /// </summary>
        [JsonPropertyName("pn")]
        public string PackageName { get; init; }

        /// <summary>
        /// 更新包统一资源定位符
        /// </summary>
        [JsonPropertyName("pu")]
        public string PackageUrl { get; init; }

        /// <summary>
        /// 更新包大小
        /// </summary>
        [JsonPropertyName("ps")]
        public long PackageSize { get; init; }

        /// <summary>
        /// 更新包 MD5
        /// </summary>
        [JsonPropertyName("md5")]
        public string PackageMD5 { get; init; }
    }
}