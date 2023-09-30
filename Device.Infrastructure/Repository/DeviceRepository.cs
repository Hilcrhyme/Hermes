using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hermes.Service.Device.Domain.Aggregate.DeviceAggregate;

namespace Hermes.Service.Device.Infrastructure.Repository
{
    /// <summary>
    /// 设备仓储
    /// </summary>
    public class DeviceRepository : IDeviceRepository
    {
        public Task<Domain.Aggregate.DeviceAggregate.Device> AddAsync(Domain.Aggregate.DeviceAggregate.Device entity)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Aggregate.DeviceAggregate.Device> UpdateAsync(Domain.Aggregate.DeviceAggregate.Device entity)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Aggregate.DeviceAggregate.Device?> GetDeviceByDeviceCodeAsync(string deviceCode)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Aggregate.DeviceAggregate.Device?> GetDeviceByConnectionIdAsync(string connectionId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Aggregate.DeviceAggregate.Device?> GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}