using Hermes.Common.SeedWork;

using Microsoft.Extensions.Logging;

namespace Hermes.Service.Device.Domain.Aggregates.DeviceAggregate
{
    /// <summary>
    /// 设备日志
    /// </summary>
    public class DeviceLog : ValueObject
    {
        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; init; } = string.Empty;

        /// <summary>
        /// 日志内容
        /// </summary>
        public string Content { get; init; } = string.Empty;

        /// <summary>
        /// 日志等级
        /// </summary>
        public LogLevel LogLevel { get; init; } = LogLevel.None;

        /// <summary>
        /// 时间戳
        /// <para>单位为毫秒</para>
        /// </summary>
        public long Timestamp { get; init; } = 0;

        /// <summary>
        /// 获取相等组件枚举
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return LogLevel;
            yield return GroupName;
            yield return GroupName;
            yield return Content;
        }
    }
}