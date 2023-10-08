using System.Text.Json.Serialization;

namespace Hermes.Service.Device.Api.Application.Command.DeviceCommand
{
    /// <summary>
    /// 设备同步更新子任务进度命令
    /// </summary>
    public class DeviceSynchronizeSubUpdateTaskProgressCommand : CommunicationCommand<SubUpdateTaskProgress>
    {
        /// <summary>
        /// 实例化设备同步更新子任务进度命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">软件更新任务进度</param>
        /// <param name="timestamp">
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </param>
        public DeviceSynchronizeSubUpdateTaskProgressCommand(string deviceCode, SubUpdateTaskProgress data, long timestamp) : base(deviceCode, data, timestamp)
        {
            Type = DeviceSynchronizeSubUpdateTaskProgressCommandType;
        }
    }

    /// <summary>
    /// 更新子任务进度
    /// </summary>
    public record class SubUpdateTaskProgress
    {
        /// <summary>
        /// 更新子任务 Id
        /// </summary>
        [JsonPropertyName("tid")]
        public long SubUpdateTaskId { get; init; } = 0;

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