using System.Text.Json.Serialization;

namespace Hermes.Service.Device.Api.Application.Commands.DeviceCommand
{
    /// <summary>
    /// 设备同步控制任务响应命令
    /// </summary>
    public class DeviceSynchronizesControlTaskResponseCommand : CommunicationCommand<DeviceControlTaskResponse>
    {
        /// <summary>
        /// 实例化设备同步控制任务响应命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">控制任务响应</param>
        /// <param name="timestamp">
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </param>
        public DeviceSynchronizesControlTaskResponseCommand(string deviceCode, DeviceControlTaskResponse data, long timestamp) : base(deviceCode, data, timestamp)
        {
            Type = DeviceSynchronizesControlTaskResponseCommandType;
        }
    }

    /// <summary>
    /// 设备控制任务响应
    /// </summary>
    public record class DeviceControlTaskResponse
    {
        /// <summary>
        /// 任务 Id
        /// </summary>
        [JsonPropertyName("tid")]
        public long TaskId { get; init; } = 0;

        /// <summary>
        /// 任务结果
        /// </summary>
        [JsonPropertyName("r")]
        public bool Result { get; init; } = false;

        /// <summary>
        /// 任务消息
        /// </summary>
        [JsonPropertyName("msg")]
        public string Message { get; init; } = string.Empty;

        /// <summary>
        /// 任务响应
        /// </summary>
        [JsonPropertyName("d")]
        public string Response { get; init; } = string.Empty;
    }
}