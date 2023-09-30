namespace Hermes.Service.Device.Api.Application.Command.PlatformCommand
{
    /// <summary>
    /// 平台要求设备停止同步日志命令
    /// </summary>
    public class PlatformRequiresDeviceStopSynchronizeLogsCommand : CommunicationCommand
    {
        /// <summary>
        /// 实例化平台要求设备停止同步日志命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        public PlatformRequiresDeviceStopSynchronizeLogsCommand(string deviceCode) : base(deviceCode)
        {
            Type = PlatformRequiresDeviceStopSynchronizeLogsCommandType;
        }
    }
}