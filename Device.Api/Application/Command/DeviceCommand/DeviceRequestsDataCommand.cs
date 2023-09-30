namespace Hermes.Service.Device.Api.Application.Command.DeviceCommand
{
    /// <summary>
    /// 设备请求数据命令
    /// </summary>
    public class DeviceRequestsDataCommand : CommunicationCommand<IEnumerable<string>>
    {
        /// <summary>
        /// 实例化设备请求数据命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">键枚举</param>
        /// <param name="timestamp">
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </param>
        public DeviceRequestsDataCommand(string deviceCode, IEnumerable<string> data, long timestamp) : base(deviceCode, data, timestamp)
        {
            Type = DeviceRequestsDataCommandType;
        }
    }
}