using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregates.UpdatePlanAggregate
{
    /// <summary>
    /// 软件
    /// </summary>
    public class Software : ValueObject
    {
        /// <summary>
        /// 软件名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 软件版本
        /// </summary>
        public string Version { get; set; } = string.Empty;

        /// <summary>
        /// 获取软件相等组件枚举
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Version;
        }
    }
}