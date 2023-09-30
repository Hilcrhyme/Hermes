using System.Linq.Expressions;

using Hermes.Common.Extension;
using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.Command.DeviceCommand;
using Hermes.Service.Device.Domain.Aggregate.DeviceAggregate;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 设备查询
    /// </summary>
    public class DeviceQuery : IDeviceQuery
    {
        /// <summary>
        /// 设备仓储
        /// </summary>
        private readonly IDeviceRepository deviceRepository;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<DeviceQuery> logger;

        /// <summary>
        /// 实例化设备查询
        /// </summary>
        /// <param name="deviceRepository">设备仓储</param>
        /// <param name="logger">日志器</param>
        public DeviceQuery(IDeviceRepository deviceRepository, ILogger<DeviceQuery> logger)
        {
            this.deviceRepository = deviceRepository;
            this.logger = logger;
        }

        /// <summary>
        /// 异步获取数据字典
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="keys">键枚举</param>
        /// <returns></returns>
        public async Task<IEnumerable<KeyValuePair<string, string?>>> GetDataDictionaryByDeviceCodeAsync(string deviceCode, IEnumerable<string> keys)
        {
            var device = await deviceRepository.GetDeviceByDeviceCodeAsync(deviceCode);
            if (device is null)
            {
                logger.LogError();
                return Enumerable.Empty<KeyValuePair<string, string?>>();
            }
            var results = new List<KeyValuePair<string, string?>>();
            foreach (var key in keys)
            {
                if (!device.DataDictionary.TryGetValue(key, out var value))
                {
                    results.Add(new KeyValuePair<string, string?>(key, null));
                }
                else
                {
                    results.Add(new KeyValuePair<string, string?>(key, value));
                }
            }
            return results;
        }

        /// <summary>
        /// 异步查询设备
        /// </summary>
        /// <param name="deviceQueryCondition">设备查询条件</param>
        /// <returns></returns>
        public async Task<QueryResult<Domain.Aggregate.DeviceAggregate.Device>> QueryDevicesAsync(DeviceQueryCondition deviceQueryCondition)
        {
            Expression<Func<Domain.Aggregate.DeviceAggregate.Device, bool>> filterExpression = p => true;
            if (deviceQueryCondition.Id is not null)
            {
                filterExpression = filterExpression.And(device => device.Id == deviceQueryCondition.Id);
            }
            if (deviceQueryCondition.Code is not null)
            {
                filterExpression = filterExpression.And(device => device.Code.Contains(deviceQueryCondition.Code));
            }
            if (deviceQueryCondition.Name is not null)
            {
                filterExpression = filterExpression.And(device => device.Name.Contains(deviceQueryCondition.Name));
            }
            if (deviceQueryCondition.Type is not null)
            {
                filterExpression = filterExpression.And(device => device.Type == deviceQueryCondition.Type);
            }
            if (deviceQueryCondition.State is not null)
            {
                filterExpression = filterExpression.And(device => device.State == deviceQueryCondition.State);
            }
            if (deviceQueryCondition.EnvironmentId is not null)
            {
                filterExpression = filterExpression.And(device => device.EnvironmentId == deviceQueryCondition.EnvironmentId);
            }
            if (deviceQueryCondition.BusinessId is not null)
            {
                filterExpression = filterExpression.And(device => device.BusinessId == deviceQueryCondition.BusinessId);
            }
            if (deviceQueryCondition.SupplierId is not null)
            {
                filterExpression = filterExpression.And(device => device.SupplierId == deviceQueryCondition.SupplierId);
            }
            if (deviceQueryCondition.BatchId is not null)
            {
                filterExpression = filterExpression.And(device => device.BatchId == deviceQueryCondition.BatchId);
            }
            if (deviceQueryCondition.CustomerId is not null)
            {
                filterExpression = filterExpression.And(device => device.CustomerId == deviceQueryCondition.CustomerId);
            }
            if (deviceQueryCondition.AreaId is not null)
            {
                filterExpression = filterExpression.And(device => device.AreaId == deviceQueryCondition.AreaId);
            }
            if (deviceQueryCondition.GroupId is not null)
            {
                filterExpression = filterExpression.And(device => device.GroupId == deviceQueryCondition.GroupId);
            }
            if (deviceQueryCondition.Location is not null)
            {
                filterExpression = filterExpression.And(device => device.Location.Contains(deviceQueryCondition.Location));
            }
            if (deviceQueryCondition.HardwareVersion is not null)
            {
                filterExpression = filterExpression.And(device => device.HardwareVersion.Contains(deviceQueryCondition.HardwareVersion));
            }
            if (deviceQueryCondition.IsConnected is not null)
            {
                filterExpression = filterExpression.And(device => device.IsConnected == deviceQueryCondition.IsConnected);
            }
            if (deviceQueryCondition.IsActivated is not null)
            {
                filterExpression = filterExpression.And(device => device.IsActivated == deviceQueryCondition.IsActivated);
            }
            if (deviceQueryCondition.IsLocked is not null)
            {
                filterExpression = filterExpression.And(device => device.IsLocked == deviceQueryCondition.IsLocked);
            }
            return await deviceRepository.GetAsync(filterExpression);
        }

        public Task<DeviceSnapshot?> GetDeviceSnapshotAsync(string deviceCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 异步获取软件更新任务
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="softwareUpdateTaskId">软件更新任务 Id</param>
        /// <returns></returns>
        public async Task<SoftwareUpdateTask?> GetSoftwareUpdateTaskAsync(string deviceCode, long softwareUpdateTaskId)
        {
            var device = await deviceRepository.GetDeviceByDeviceCodeAsync(deviceCode);
            if (device is null)
            {
                logger.LogError();
                return null;
            }
            return device.SoftwareUpdateTasks.FirstOrDefault(softwareUpdateTask => softwareUpdateTask.Id == softwareUpdateTaskId);
        }

        /// <summary>
        /// 异步获取软件更新任务枚举
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <returns></returns>
        public async Task<IEnumerable<SoftwareUpdateTask>> GetSoftwareUpdateTasksAsync(string deviceCode)
        {
            var device = await deviceRepository.GetDeviceByDeviceCodeAsync(deviceCode);
            if (device is null)
            {
                logger.LogError();
                return Enumerable.Empty<SoftwareUpdateTask>();
            }
            return device.SoftwareUpdateTasks;
        }
    }
}