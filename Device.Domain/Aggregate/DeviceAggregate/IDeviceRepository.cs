using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.DeviceAggregate
{
    /// <summary>
    /// 设备仓储接口
    /// </summary>
    public interface IDeviceRepository : IRepository<Device>
    {
        /// <summary>
        /// 异步根据设备代码获取设备
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <returns></returns>
        Task<Device?> GetDeviceByDeviceCodeAsync(string deviceCode);

        /// <summary>
        /// 异步根据连接 Id 获取设备
        /// </summary>
        /// <param name="connectionId">连接 Id</param>
        /// <returns></returns>
        Task<Device?> GetDeviceByConnectionIdAsync(long connectionId);

        /// <summary>
        /// 异步查询设备日志
        /// </summary>
        /// <param name="deviceId">设备 Id</param>
        /// <param name="options">设备日志查询选项</param>
        /// <returns></returns>
        Task<QueryResult<DeviceLog>> QueryDeviceLogsAsync(long deviceId, QueryOptions<DeviceLog> options);
    }
}