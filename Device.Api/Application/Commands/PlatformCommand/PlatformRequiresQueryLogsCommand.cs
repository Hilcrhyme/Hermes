using System.Text.Json.Serialization;

namespace Hermes.Service.Device.Api.Application.Commands.PlatformCommand
{
    /// <summary>
    /// 平台要求查询日志命令
    /// </summary>
    public class PlatformRequiresQueryLogsCommand : CommunicationCommand<LogQuery>
    {
        /// <summary>
        /// 实例化平台要求查询日志命令
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">日志查询</param>
        public PlatformRequiresQueryLogsCommand(string deviceCode, LogQuery data) : base(deviceCode, data)
        {
            Type = PlatformRequiresQueryLogsCommandType;
        }
    }

    /// <summary>
    /// 日志查询
    /// </summary>
    public record class LogQuery
    {
        /// <summary>
        /// 查询起始时间戳
        /// <para>单位为毫秒</para>
        /// </summary>
        [JsonPropertyName("sts")]
        public long StartTimestamp { get; init; } = 0;

        /// <summary>
        /// 查询结束时间戳
        /// <para>单位为毫秒</para>
        /// </summary>
        [JsonPropertyName("ets")]
        public long EndTimestamp { get; init; } = 0;

        /// <summary>
        /// 查询的日志等级
        /// <para>设备同步的日志的日志等级需大于查询的日志等级</para>
        /// </summary>
        [JsonPropertyName("ll")]
        public LogLevel LogLevel { get; init; } = LogLevel.None;
    }
}