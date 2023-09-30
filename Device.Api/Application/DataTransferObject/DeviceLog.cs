namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 设备日志
    /// </summary>
    public readonly record struct DeviceLog
    {
        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; init; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string Content { get; init; }

        /// <summary>
        /// 日志等级
        /// </summary>
        public LogLevel LogLevel { get; init; }

        /// <summary>
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </summary>
        public long Timestamp { get; init; }
    }
}