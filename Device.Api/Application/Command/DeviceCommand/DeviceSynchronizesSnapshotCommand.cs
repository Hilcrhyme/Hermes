using System.Text.Json.Serialization;

namespace Hermes.Service.Device.Api.Application.Command.DeviceCommand
{
    /// <summary>
    /// 设备同步快照命令
    /// </summary>
    public class DeviceSynchronizesSnapshotCommand : CommunicationCommand<DeviceSnapshot>
    {
        /// <summary>
        /// 实例化设备同步快照命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">设备同步快照命令</param>
        /// <param name="timestamp">
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </param>
        public DeviceSynchronizesSnapshotCommand(string deviceCode, DeviceSnapshot data, long timestamp) : base(deviceCode, data, timestamp)
        {
            Type = DeviceSynchronizesSnapshotCommandType;
        }
    }

    /// <summary>
    /// 设备快照
    /// </summary>
    public record class DeviceSnapshot
    {
        /// <summary>
        /// 业务 Id
        /// </summary>
        [JsonPropertyName("bid")]
        public long BusinessId { get; set; } = 0;

        /// <summary>
        /// 软件枚举
        /// </summary>
        [JsonPropertyName("svs")]
        public IEnumerable<Software> Softwares { get; set; } = Enumerable.Empty<Software>();

        /// <summary>
        /// 硬件版本
        /// </summary>
        [JsonPropertyName("hv")]
        public string HardwareVersion { get; set; } = string.Empty;

        /// <summary>
        /// 经度
        /// </summary>
        [JsonPropertyName("lng")]
        public string Longitude { get; set; } = string.Empty;

        /// <summary>
        /// 纬度
        /// </summary>
        [JsonPropertyName("lat")]
        public string Latitude { get; set; } = string.Empty;

        /// <summary>
        /// 坐标系
        /// </summary>
        [JsonPropertyName("cs")]
        public string CoordinateSystem { get; set; } = string.Empty;
    }

    /// <summary>
    /// 软件
    /// </summary>
    public record class Software
    {
        /// <summary>
        /// 软件名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 软件版本
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; } = string.Empty;
    }
}