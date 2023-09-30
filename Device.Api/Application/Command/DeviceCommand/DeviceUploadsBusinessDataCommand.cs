using System.Text.Json.Serialization;

namespace Hermes.Service.Device.Api.Application.Command.DeviceCommand
{
    /// <summary>
    /// 设备上传业务数据命令
    /// </summary>
    public class DeviceUploadsBusinessDataCommand : CommunicationCommand<BusinessData>
    {
        /// <summary>
        /// 实例化设备上传业务数据命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">业务数据</param>
        /// <param name="timestamp">
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </param>
        public DeviceUploadsBusinessDataCommand(string deviceCode, BusinessData data, long timestamp) : base(deviceCode, data, timestamp)
        {
            Type = DeviceUploadsBusinessDataCommandType;
        }
    }

    /// <summary>
    /// 业务数据
    /// </summary>
    public record class BusinessData
    {
        /// <summary>
        /// 分组名称
        /// </summary>
        [JsonPropertyName("gn")]
        public string GroupName { get; set; } = string.Empty;

        /// <summary>
        /// 数据内容
        /// </summary>
        [JsonPropertyName("c")]
        public string Content { get; set; } = string.Empty;
    }
}