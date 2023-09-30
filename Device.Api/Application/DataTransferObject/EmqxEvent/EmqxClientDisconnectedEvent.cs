namespace Hermes.Service.Device.Api.Application.DataTransferObject.EmqxEvent
{
    /// <summary>
    /// Emqx 客户端连接已断开事件
    /// </summary>
    public record EmqxClientDisconnectedEvent : EmqxEvent
    {
        /// <summary>
        /// 原因
        /// </summary>
        public string Reason { get; init; } = string.Empty;

        /// <summary>
        /// 连接断开时间
        /// <para>单位为毫秒</para>
        /// </summary>
        public long DisconnectedAt { get; init; } = 0;
    }
}