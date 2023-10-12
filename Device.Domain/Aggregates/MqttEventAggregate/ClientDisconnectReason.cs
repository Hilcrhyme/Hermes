namespace Hermes.Service.Device.Domain.Aggregates.MqttEventAggregate
{
    /// <summary>
    /// 客户端连接断开原因
    /// </summary>
    public enum ClientDisconnectReason
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 客户端正常退出
        /// </summary>
        Normal = 1,

        /// <summary>
        /// 服务端踢出
        /// </summary>
        Kicked = 2,

        /// <summary>
        /// 保持连接超时
        /// </summary>
        KeepaliveTimeout = 3,

        /// <summary>
        /// 未认证
        /// </summary>
        NotAuthorized = 4,

        /// <summary>
        /// Tcp 连接已关闭
        /// </summary>
        TcpClosed = 5,

        /// <summary>
        /// 被丢弃
        /// <para>另一个客户端使用相同的客户端 Id 连接，并设置 CLEAN_START = TRUE</para>
        /// </summary>
        Discarded = 6,

        /// <summary>
        /// 被接管
        /// <para>另一个客户端使用相同的客户端 Id 连接，并设置 CLEAN_START = FALSE</para>
        /// </summary>
        Takenover = 7,

        /// <summary>
        /// 内部错误
        /// <para>畸形报文或未知错误</para>
        /// </summary>
        InternalError = 8
    }
}