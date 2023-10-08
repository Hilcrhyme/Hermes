namespace Hermes.Service.Device.Api.Application.Command
{
    /// <summary>
    /// 设备日志查询命令
    /// </summary>
    public record class DeviceLogQueryCommand : QueryCommand
    {
        /// <summary>
        /// 分组名称
        /// </summary>
        public string? GroupName { get; init; } = string.Empty;

        /// <summary>
        /// 查询的起始时间
        /// </summary>
        public DateTime? StartTime { get; init; } = DateTime.MinValue;

        /// <summary>
        /// 查询的结束时间
        /// </summary>
        public DateTime? EndTime { get; init; } = DateTime.MaxValue;
    }
}