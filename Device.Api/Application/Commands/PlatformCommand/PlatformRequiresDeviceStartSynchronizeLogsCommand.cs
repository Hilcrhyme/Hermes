namespace Hermes.Service.Device.Api.Application.Commands.PlatformCommand
{
    /// <summary>
    /// 平台要求设备开始同步日志命令
    /// </summary>
    public class PlatformRequiresDeviceStartSynchronizeLogsCommand : CommunicationCommand
    {
        /// <summary>
        /// 实例化平台要求设备开始同步日志命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        public PlatformRequiresDeviceStartSynchronizeLogsCommand(string deviceCode) : base(deviceCode)
        {
            Type = PlatformRequiresDeviceStartSynchronizeLogsCommandType;
        }
    }
}