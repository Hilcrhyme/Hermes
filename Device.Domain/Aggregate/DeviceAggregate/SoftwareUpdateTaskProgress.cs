using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.DeviceAggregate
{
    /// <summary>
    /// 软件更新任务进度
    /// </summary>
    public class SoftwareUpdateTaskProgress : ValueObject
    {
        /// <summary>
        /// 软件更新任务 Id
        /// </summary>
        public long SoftwareUpdateTaskId { get; init; } = 0;

        /// <summary>
        /// 进度值
        /// </summary>
        public int Value { get; init; } = 0;

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; init; } = string.Empty;

        /// <summary>
        /// 同步的时间
        /// </summary>
        public DateTime SynchronizedTime { get; init; } = DateTime.MinValue;

        /// <summary>
        /// 获取相等组件枚举
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SoftwareUpdateTaskId;
            yield return Value;
            yield return Message;
            yield return SynchronizedTime;
        }
    }
}