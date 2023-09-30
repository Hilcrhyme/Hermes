using System.Text.Json.Serialization;

namespace Hermes.Service.Device.Api.Application.Command.PlatformCommand
{
    /// <summary>
    /// 平台推送设备控制任务命令
    /// </summary>
    public class PlatformPushsDeviceControlTaskCommand : CommunicationCommand<DeviceControlTask>
    {
        /// <summary>
        /// 实例化平台推送设备控制任务命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">设备控制任务</param>
        public PlatformPushsDeviceControlTaskCommand(string deviceCode, DeviceControlTask data) : base(deviceCode, data)
        {
        }
    }


    /// <summary>
    /// 设备控制任务
    /// </summary>
    public record class DeviceControlTask
    {
        /// <summary>
        /// 任务 Id
        /// </summary>
        [JsonPropertyName("tid")]
        public long TaskId { get; init; } = 0;

        /// <summary>
        /// 任务超时
        /// </summary>
        [JsonPropertyName("t")]
        public int Timeout { get; init; } = 0;

        /// <summary>
        /// 任务数据
        /// </summary>
        [JsonPropertyName("d")]
        public string Data { get; init; } = string.Empty;
    }
}