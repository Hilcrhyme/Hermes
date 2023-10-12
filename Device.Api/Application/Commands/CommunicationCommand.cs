using Hermes.Common.Extension;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands
{
    /// <summary>
    /// 通信命令
    /// </summary>
    public abstract class CommunicationCommand : IRequest
    {
        /// <summary>
        /// 平台要求同步时间命令类型
        /// </summary>
        public static string PlatformRequiresSynchronizeTimeCommandType => "sync-time";

        /// <summary>
        /// 设备请求数据命令类型
        /// </summary>
        public static string DeviceRequestsDataCommandType => "get-data";

        /// <summary>
        /// 平台响应数据命令类型
        /// </summary>
        public static string PlatformRespondsDataCommandType => "get-data-result";

        /// <summary>
        /// 平台推送设备控制任务命令类型
        /// </summary>
        public static string PlatformPushsDeviceControlTaskCommandType => "control-task";

        /// <summary>
        /// 设备同步控制任务响应命令类型
        /// </summary>
        public static string DeviceSynchronizesControlTaskResponseCommandType => "control-task-response";

        /// <summary>
        /// 平台要求查询日志命令类型
        /// </summary>
        public static string PlatformRequiresQueryLogsCommandType => "query-logs";

        /// <summary>
        /// 平台要求设备开始同步日志命令类型
        /// </summary>
        public static string PlatformRequiresDeviceStartSynchronizeLogsCommandType => "start-sync-logs";

        /// <summary>
        /// 平台要求设备停止同步日志命令类型
        /// </summary>
        public static string PlatformRequiresDeviceStopSynchronizeLogsCommandType => "stop-sync-logs";

        /// <summary>
        /// 设备同步日志命令类型
        /// </summary>
        public static string DeviceSynchronizesLogCommandType => "logs";

        /// <summary>
        /// 平台要求更新命令类型
        /// </summary>
        public static string PlatformRequiresUpdateCommandType => "update";

        /// <summary>
        /// 设备同步更新进度命令类型
        /// </summary>
        public static string DeviceSynchronizeUpdateProgressCommandType => "update-progress";

        /// <summary>
        /// 设备同步快照命令类型
        /// </summary>
        public static string DeviceSynchronizesSnapshotCommandType => "snapshot";

        /// <summary>
        /// 设备上传业务数据命令类型
        /// </summary>
        public static string DeviceUploadsBusinessDataCommandType => "business-data";

        /// <summary>
        /// 设备代码
        /// </summary>
        public string DeviceCode { get; init; }

        /// <summary>
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </summary>
        public long Timestamp { get; init; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; protected init; }

        /// <summary>
        /// 实例化通信命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        public CommunicationCommand(string deviceCode) : this(deviceCode, DateTime.UtcNow.ToUnixTimeMilliseconds())
        {

        }

        /// <summary>
        /// 实例化通信命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="timestamp">
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </param>
        public CommunicationCommand(string deviceCode, long timestamp)
        {
            DeviceCode = deviceCode;
            Timestamp = timestamp;
            Type = "Unknown";
        }
    }

    /// <summary>
    /// 通信命令
    /// </summary>
    /// <typeparam name="T">数据的类型</typeparam>
    public abstract class CommunicationCommand<T> : CommunicationCommand
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; init; }

        /// <summary>
        /// 实例化通信命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data"></param>
        public CommunicationCommand(string deviceCode, T data) : base(deviceCode, DateTime.UtcNow.ToUnixTimeMilliseconds())
        {
            Data = data;
        }

        /// <summary>
        /// 实例化通信命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">数据</param>
        /// <param name="timestamp">
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </param>
        public CommunicationCommand(string deviceCode, T data, long timestamp) : base(deviceCode, timestamp)
        {
            Data = data;
        }
    }
}