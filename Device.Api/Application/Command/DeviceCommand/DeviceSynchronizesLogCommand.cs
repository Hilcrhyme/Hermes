using System.Text.Json.Serialization;

namespace Hermes.Service.Device.Api.Application.Command.DeviceCommand
{
    /// <summary>
    /// 设备同步日志命令
    /// </summary>
    public class DeviceSynchronizesLogCommand : CommunicationCommand<IEnumerable<DeviceLog>>
    {
        /// <summary>
        /// 实例化设备同步日志命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">设备日志枚举</param>
        /// <param name="timestamp">
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </param>
        public DeviceSynchronizesLogCommand(string deviceCode, IEnumerable<DeviceLog> data, long timestamp) : base(deviceCode, data, timestamp)
        {
            Type = DeviceSynchronizesLogCommandType;
        }
    }

    /// <summary>
    /// 设备日志
    /// </summary>
    public record class DeviceLog
    {
        /// <summary>
        /// 分组名称
        /// </summary>
        [JsonPropertyName("gn")]
        public string GroupName { get; set; } = string.Empty;

        /// <summary>
        /// 日志内容
        /// </summary>
        [JsonPropertyName("c")]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// 日志等级
        /// </summary>
        [JsonPropertyName("ll")]
        public LogLevel LogLevel { get; set; } = LogLevel.None;

        /// <summary>
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </summary>
        [JsonPropertyName("ts")]
        public long Timestamp { get; set; } = 0;
    }
}