namespace Hermes.Service.Device.Api.Application.Commands.PlatformCommand
{
    /// <summary>
    /// 平台响应数据命令
    /// </summary>
    public class PlatformRespondsDataCommand : CommunicationCommand<IEnumerable<KeyValuePair<string, string?>>>
    {
        /// <summary>
        /// 实例化平台响应数据命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">数据</param>
        public PlatformRespondsDataCommand(string deviceCode, IEnumerable<KeyValuePair<string, string?>> data) : base(deviceCode, data)
        {
            Type = PlatformRespondsDataCommandType;
        }
    }
}