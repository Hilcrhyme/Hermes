using System.Text.Json.Serialization;

namespace Hermes.Service.Device.Api.Application.Commands.DeviceCommand
{
    /// <summary>
    /// 设备同步更新进度命令
    /// </summary>
    public class DeviceSynchronizeUpdateProgressCommand : CommunicationCommand<UpdateProgress>
    {
        /// <summary>
        /// 实例化设备同步更新进度命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">更新进度</param>
        /// <param name="timestamp">
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </param>
        public DeviceSynchronizeUpdateProgressCommand(string deviceCode, UpdateProgress data, long timestamp) : base(deviceCode, data, timestamp)
        {
            Type = DeviceSynchronizeUpdateProgressCommandType;
        }
    }

    /// <summary>
    /// 更新进度
    /// </summary>
    public readonly record struct UpdateProgress
    {
        /// <summary>
        /// 更新任务 Id
        /// </summary>
        [JsonPropertyName("tid")]
        public long UpdateTaskId { get; init; }

        /// <summary>
        /// 进度值
        /// </summary>
        [JsonPropertyName("pg")]
        public int Value { get; init; }

        /// <summary>
        /// 消息
        /// </summary>
        [JsonPropertyName("msg")]
        public string Message { get; init; }
    }
}