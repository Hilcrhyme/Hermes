using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregates.UpdatePlanAggregate
{
    /// <summary>
    /// 更新任务进度
    /// </summary>
    public class UpdateTaskProgress : ValueObject
    {
        /// <summary>
        /// 更新任务 Id
        /// </summary>
        public long UpdateTaskId { get; init; } = 0;

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
        /// 获取更新任务进度的相等组件枚举
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UpdateTaskId;
            yield return Value;
            yield return Message;
            yield return SynchronizedTime;
        }
    }
}