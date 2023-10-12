namespace Hermes.Service.Device.Api.Application.Commands.PlatformCommand
{
    /// <summary>
    /// 平台要求同步时间命令
    /// </summary>
    public class PlatformRequiresSynchronizeTimeCommand : CommunicationCommand
    {
        /// <summary>
        /// 实例化平台要求同步时间命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        public PlatformRequiresSynchronizeTimeCommand(string deviceCode) : base(deviceCode)
        {
            Type = PlatformRequiresSynchronizeTimeCommandType;
        }
    }
}