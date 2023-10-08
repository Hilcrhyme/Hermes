using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.UpdateTaskAggregate
{
    /// <summary>
    /// 更新子任务进度
    /// </summary>
    public class SubUpdateTaskProgress : ValueObject
    {
        /// <summary>
        /// 更新子任务 Id
        /// </summary>
        public long SubUpdateTaskId { get; init; } = 0;

        /// <summary>
        /// 进度值
        /// </summary>
        public int Value { get; init; } = 0;

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; init; } = string.Empty;

        /// <summary>
        /// 同步时间
        /// </summary>
        public DateTime SynchronizedTime { get; init; } = DateTime.MinValue;

        /// <summary>
        /// 获取更新子任务进度的相等组件枚举
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SubUpdateTaskId;
            yield return Value;
            yield return Message;
            yield return SynchronizedTime;
        }
    }
}