using System.Linq.Expressions;

using AutoMapper;

using Hermes.Common.Extension;
using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.Command;
using Hermes.Service.Device.Api.Application.Command.DeviceCommand;
using Hermes.Service.Device.Api.Application.DataTransferObject;
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
        /// 映射器
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<DeviceQuery> logger;

        /// <summary>
        /// 实例化设备查询
        /// </summary>
        /// <param name="deviceRepository">设备仓储</param>
        /// <param name="mapper">映射器</param>
        /// <param name="logger">日志器</param>
        public DeviceQuery(IDeviceRepository deviceRepository, IMapper mapper, ILogger<DeviceQuery> logger)
        {
            this.deviceRepository = deviceRepository;
            this.mapper = mapper;
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
        /// <param name="deviceQueryCommand">设备查询命令</param>
        /// <returns></returns>
        public async Task<QueryResult<DataTransferObject.Device>> QueryDevicesAsync(DeviceQueryCommand deviceQueryCommand)
        {
            Expression<Func<Domain.Aggregate.DeviceAggregate.Device, bool>> filterExpression = p => true;
            if (deviceQueryCommand.Id is not null)
            {
                filterExpression = filterExpression.And(device => device.Id == deviceQueryCommand.Id);
            }
            if (deviceQueryCommand.Code is not null)
            {
                filterExpression = filterExpression.And(device => device.Code.Contains(deviceQueryCommand.Code));
            }
            if (deviceQueryCommand.Name is not null)
            {
                filterExpression = filterExpression.And(device => device.Name.Contains(deviceQueryCommand.Name));
            }
            if (deviceQueryCommand.Type is not null)
            {
                filterExpression = filterExpression.And(device => device.Type == deviceQueryCommand.Type);
            }
            if (deviceQueryCommand.State is not null)
            {
                filterExpression = filterExpression.And(device => device.State == deviceQueryCommand.State);
            }
            if (deviceQueryCommand.EnvironmentId is not null)
            {
                filterExpression = filterExpression.And(device => device.EnvironmentId == deviceQueryCommand.EnvironmentId);
            }
            if (deviceQueryCommand.BusinessId is not null)
            {
                filterExpression = filterExpression.And(device => device.BusinessId == deviceQueryCommand.BusinessId);
            }
            if (deviceQueryCommand.SupplierId is not null)
            {
                filterExpression = filterExpression.And(device => device.SupplierId == deviceQueryCommand.SupplierId);
            }
            if (deviceQueryCommand.BatchId is not null)
            {
                filterExpression = filterExpression.And(device => device.BatchId == deviceQueryCommand.BatchId);
            }
            if (deviceQueryCommand.CustomerId is not null)
            {
                filterExpression = filterExpression.And(device => device.CustomerId == deviceQueryCommand.CustomerId);
            }
            if (deviceQueryCommand.AreaId is not null)
            {
                filterExpression = filterExpression.And(device => device.AreaId == deviceQueryCommand.AreaId);
            }
            if (deviceQueryCommand.GroupId is not null)
            {
                filterExpression = filterExpression.And(device => device.GroupId == deviceQueryCommand.GroupId);
            }
            if (deviceQueryCommand.Location is not null)
            {
                filterExpression = filterExpression.And(device => device.Location.Contains(deviceQueryCommand.Location));
            }
            if (deviceQueryCommand.HardwareVersion is not null)
            {
                filterExpression = filterExpression.And(device => device.HardwareVersion.Contains(deviceQueryCommand.HardwareVersion));
            }
            if (deviceQueryCommand.IsConnected is not null)
            {
                filterExpression = filterExpression.And(device => device.IsConnected == deviceQueryCommand.IsConnected);
            }
            if (deviceQueryCommand.IsActivated is not null)
            {
                filterExpression = filterExpression.And(device => device.IsActivated == deviceQueryCommand.IsActivated);
            }
            if (deviceQueryCommand.IsLocked is not null)
            {
                filterExpression = filterExpression.And(device => device.IsLocked == deviceQueryCommand.IsLocked);
            }
            var queryOptions = new QueryOptions<Domain.Aggregate.DeviceAggregate.Device>
            {
                Filter = filterExpression
            };
            var result = await deviceRepository.QueryAsync(queryOptions);
            return new QueryResult<DataTransferObject.Device>()
            {
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                Items = result.Items.Select(mapper.Map<DataTransferObject.Device>)
            };
        }

        public Task<DeviceSnapshot?> GetDeviceSnapshotAsync(string deviceCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 异步查询设备日志
        /// </summary>
        /// <param name="deviceId">设备 Id</param>
        /// <param name="deviceLogQueryCommand">设备日志查询命令</param>
        /// <returns></returns>
        public async Task<QueryResult<DataTransferObject.DeviceLog>> QueryDeviceLogsAsync(long deviceId, DeviceLogQueryCommand deviceLogQueryCommand)
        {
            Expression<Func<Domain.Aggregate.DeviceAggregate.DeviceLog, bool>> filterExpression = p => true;
            if (deviceLogQueryCommand.GroupName is not null)
            {
                filterExpression = filterExpression.And(log => log.GroupName.Contains(deviceLogQueryCommand.GroupName));
            }
            if (deviceLogQueryCommand.StartTime is not null)
            {
                var startTimestamp = deviceLogQueryCommand.StartTime is null ? 0 : deviceLogQueryCommand.StartTime.Value.ToUnixTimeMilliseconds();
                filterExpression = filterExpression.And(log => log.Timestamp >= startTimestamp);
            }
            if (deviceLogQueryCommand.EndTime is not null)
            {
                var endTimestamp = deviceLogQueryCommand.EndTime is null ? 0 : deviceLogQueryCommand.EndTime.Value.ToUnixTimeMilliseconds();
                filterExpression = filterExpression.And(log => log.Timestamp <= endTimestamp);
            }
            var queryOptions = new QueryOptions<Domain.Aggregate.DeviceAggregate.DeviceLog>()
            {
                Filter = filterExpression
            };
            var result = await deviceRepository.QueryDeviceLogsAsync(deviceId, queryOptions);
            return new QueryResult<DataTransferObject.DeviceLog>()
            {
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                Items = result.Items.Select(mapper.Map<DataTransferObject.DeviceLog>)
            };
        }

        /// <summary>
        /// 异步获取软件更新任务
        /// </summary>
        /// <param name="softwareUpdateTaskId">软件更新任务 Id</param>
        /// <returns></returns>
        public async Task<DataTransferObject.SoftwareUpdateTask?> GetSoftwareUpdateTaskAsync(long softwareUpdateTaskId)
        {
            var task = await deviceRepository.GetSoftwareUpdateTaskAsync(softwareUpdateTaskId);
            return mapper.Map<DataTransferObject.SoftwareUpdateTask>(task);
        }

        public async Task<QueryResult<DataTransferObject.SoftwareUpdateTask>> GetSoftwareUpdateTasksAsync(SoftwareUpdateTaskQueryCommand softwareUpdateTaskQueryCommand)
        {
            Expression<Func<Domain.Aggregate.DeviceAggregate.SoftwareUpdateTask, bool>> filterExpression = p => true;
            if (softwareUpdateTaskQueryCommand.SoftwareUpdateTaskId is not null)
            {
                filterExpression = filterExpression.And(softwareUpdateTask => softwareUpdateTask.Id == softwareUpdateTaskQueryCommand.SoftwareUpdateTaskId);
            }
            if (softwareUpdateTaskQueryCommand.SoftwareUpdateTaskName is not null)
            {
                filterExpression = filterExpression.And(softwareUpdateTask => softwareUpdateTask.Name.Contains(softwareUpdateTaskQueryCommand.SoftwareUpdateTaskName));
            }
            var queryOptions = new QueryOptions<Domain.Aggregate.DeviceAggregate.SoftwareUpdateTask>()
            {
                Filter = filterExpression
            };
            var result = await deviceRepository.QueryDeviceLogsAsync(deviceId, queryOptions);
            return new QueryResult<DataTransferObject.DeviceLog>()
            {
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                Items = result.Items.Select(mapper.Map<DataTransferObject.SoftwareUpdateTask>)
            };
        }

        public Task<QueryResult<DataTransferObject.DeviceControlTask>> GetDeviceControlTasksAsync(long deviceId)
        {
            throw new NotImplementedException();
        }

        public Task<DataTransferObject.DeviceControlTask?> GetDeviceControlTaskAsync(long deviceId, long taskId)
        {
            throw new NotImplementedException();
        }
    }
}