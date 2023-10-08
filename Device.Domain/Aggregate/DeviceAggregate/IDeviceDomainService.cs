namespace Hermes.Service.Device.Domain.Aggregate.DeviceAggregate
{
    /// <summary>
    /// 设备领域服务接口
    /// </summary>
    public interface IDeviceDomainService
    {
        /// <summary>
        /// 异步激活设备
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="connectionIds">连接 Id 枚举</param>
        /// <returns></returns>
        Task ActivateDeviceAsync(string deviceCode, IEnumerable<long> connectionIds);

        /// <summary>
        /// 异步添加连接
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="connection">连接</param>
        /// <returns></returns>
        Task AddConnectionAsync(string deviceCode, Connection connection);

        /// <summary>
        /// 异步添加连接枚举
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="connections">连接枚举</param>
        /// <returns></returns>
        Task AddConnectionsAsync(string deviceCode, IEnumerable<Connection> connections);

        /// <summary>
        /// 异步移除连接
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="connectionId">连接 Id</param>
        /// <returns></returns>
        Task RemoveConnectionAsync(string deviceCode, long connectionId);

        /// <summary>
        /// 异步移除所有连接
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <returns></returns>
        Task RemoveAllConnectionsAsync(string deviceCode);

        /// <summary>
        /// 异步以 Mqtt 连接连接设备
        /// </summary>
        /// <param name="clientId">客户端 Id</param>
        /// <returns></returns>
        Task ConnectByMqttConnectionAsync(string clientId);

        /// <summary>
        /// 异步以 Mqtt 连接断开连接设备
        /// </summary>
        /// <param name="clientId">客户端 Id</param>
        /// <returns></returns>
        Task DisconnectByMqttConnectionAsync(string clientId);

        /// <summary>
        /// 异步锁定设备
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <returns></returns>
        Task LockDeviceAsync(string deviceCode);

        /// <summary>
        /// 异步解除锁定设备
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <returns></returns>
        Task UnlockDeviceAsync(string deviceCode);

        /// <summary>
        /// 异步创建设备控制任务
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="data">任务数据</param>
        /// <param name="timeout">任务超时时间</param>
        /// <returns></returns>
        Task<long> CreateDeviceControlTaskAsync(string deviceCode, string data, TimeSpan timeout);

        /// <summary>
        /// 异步更新设备控制任务
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="taskId">任务 Id</param>
        /// <param name="result">任务结果</param>
        /// <param name="message">消息</param>
        /// <param name="response">任务响应</param>
        /// <returns></returns>
        Task UpdateDeviceControlTaskAsync(string deviceCode, long taskId, bool result, string message, string response);

        /// <summary>
        /// 异步添加可列举的设备日志
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <param name="logs">设备日志枚举</param>
        /// <returns></returns>
        Task AddDeviceLogsAsync(string deviceCode, IEnumerable<DeviceLog> logs);
    }
}