namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// Mqtt 连接查询接口
    /// </summary>
    public interface IMqttConnectionQuery
    {
        /// <summary>
        /// 异步获取通知主题枚举
        /// </summary>
        /// <param name="deviceCode">设备代码</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetNotificationTopicsAsync(string deviceCode);
    }
}