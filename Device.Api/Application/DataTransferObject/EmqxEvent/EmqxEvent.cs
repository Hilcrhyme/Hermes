namespace Hermes.Service.Device.Api.Application.DataTransferObject.EmqxEvent
{
    /// <summary>
    /// Emqx 事件
    /// </summary>
    public abstract record EmqxEvent
    {
        /// <summary>
        /// 客户端 Id
        /// </summary>
        public string ClientId { get; init; } = string.Empty;

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Username { get; init; } = string.Empty;

        /// <summary>
        /// 事件触发时间
        /// <para>单位为毫秒</para>
        /// </summary>
        public long Timestamp { get; init; } = 0;
    }
}