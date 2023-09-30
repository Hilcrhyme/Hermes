namespace Hermes.Service.Device.Api.Application.DataTransferObject.EmqxEvent
{
    /// <summary>
    /// Emqx 客户端已连接事件
    /// </summary>
    public record EmqxClientConnectedEvent : EmqxEvent
    {
        /// <summary>
        /// 连接完成时间
        /// <para>单位为毫秒</para>
        /// </summary>
        public long ConnectedAt { get; init; } = 0;
    }
}