using Microsoft.EntityFrameworkCore;

namespace Hermes.Service.Device.Infrastructure.Repository
{
    /// <summary>
    /// 设备上下文
    /// </summary>
    public class DeviceContext : DbContext
    {
        /// <summary>
        /// 设备数据集
        /// </summary>
        public DbSet<Domain.Aggregate.DeviceAggregate.Device> Devices { get; set; }
    }
}