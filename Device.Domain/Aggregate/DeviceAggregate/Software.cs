using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.DeviceAggregate
{
    /// <summary>
    /// 软件
    /// </summary>
    public class Software : Entity
    {
        /// <summary>
        /// 软件名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 软件版本
        /// </summary>
        public string Version { get; set; } = string.Empty;
    }
}