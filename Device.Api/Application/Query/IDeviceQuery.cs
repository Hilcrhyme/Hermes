using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.Command.DeviceCommand;
using Hermes.Service.Device.Api.Application.DataTransferObject;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 设备查询接口
    /// </summary>
    public interface IDeviceQuery
    {
        /// <summary>
        /// 异步查询设备
        /// </summary>
        /// <param name="deviceQueryCondition">设备查询条件</param>
        /// <returns></returns>
        Task<QueryResult<DataTransferObject.Device>> QueryDevicesAsync(DeviceQueryCondition deviceQueryCondition);

        /// <summary>
        /// 异步根据设备代码获取数据字典
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="keys">键枚举</param>
        /// <returns></returns>
        Task<IEnumerable<KeyValuePair<string, string?>>> GetDataDictionaryByDeviceCodeAsync(string deviceCode, IEnumerable<string> keys);

        /// <summary>
        /// 异步查询设备日志
        /// </summary>
        /// <param name="deviceId">设备 Id</param>
        /// <param name="startTime">查询的开始时间</param>
        /// <param name="endTime">查询的结束时间</param>
        /// <returns></returns>
        Task<QueryResult<DataTransferObject.DeviceLog>> QueryDeviceLogsAsync(long deviceId, DateTime? startTime, DateTime? endTime);

        /// <summary>
        /// 异步根据设备代码获取软件更新任务枚举
        /// </summary>
        /// <param name="deviceId">设备 Id</param>
        /// <returns></returns>
        Task<QueryResult<SoftwareUpdateTask>> GetSoftwareUpdateTasksAsync(long deviceId);

        /// <summary>
        /// 异步根据任务 Id 获取软件更新任务
        /// </summary>
        /// <param name="softwareUpdateTaskId">软件更新任务 Id</param>
        /// <returns></returns>
        Task<SoftwareUpdateTask?> GetSoftwareUpdateTaskByTaskIdAsync(long softwareUpdateTaskId);

        /// <summary>
        /// 异步查询设备控制任务
        /// </summary>
        /// <param name="deviceId">设备 Id</param>
        /// <returns></returns>
        Task<QueryResult<DeviceControlTask>> GetDeviceControlTasksAsync(long deviceId);

        /// <summary>
        /// 异步获取设备控制任务
        /// </summary>
        /// <param name="deviceId">设备 Id</param>
        /// <param name="taskId">设备控制任务 Id</param>
        /// <returns></returns>
        Task<DeviceControlTask?> GetDeviceControlTaskAsync(long deviceId, long taskId);

        /// <summary>
        /// 异步获取设备快照
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <returns></returns>
        Task<DeviceSnapshot?> GetDeviceSnapshotAsync(string deviceCode);
    }
}