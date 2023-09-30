using System.Text.Json.Serialization;

namespace Hermes.Service.Device.Api.Application.Command.DeviceCommand
{
    /// <summary>
    /// 设备同步软件更新任务进度命令
    /// </summary>
    public class DeviceSynchronizeSoftwareUpdateTaskProgressCommand : CommunicationCommand<SoftwareUpdateTaskProgress>
    {
        /// <summary>
        /// 实例化设备同步软件更新任务进度命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">软件更新任务进度</param>
        /// <param name="timestamp">
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </param>
        public DeviceSynchronizeSoftwareUpdateTaskProgressCommand(string deviceCode, SoftwareUpdateTaskProgress data, long timestamp) : base(deviceCode, data, timestamp)
        {
            Type = DeviceSynchronizeSoftwareUpdateTaskProgressCommandType;
        }
    }

    /// <summary>
    /// 软件更新任务进度
    /// </summary>
    public record class SoftwareUpdateTaskProgress
    {
        /// <summary>
        /// 更新任务 Id
        /// </summary>
        [JsonPropertyName("tid")]
        public string TaskId { get; init; } = string.Empty;

        /// <summary>
        /// 进度值
        /// </summary>
        [JsonPropertyName("pg")]
        public int Value { get; init; } = 0;

        /// <summary>
        /// 消息
        /// </summary>
        [JsonPropertyName("msg")]
        public string Message { get; init; } = string.Empty;
    }
}