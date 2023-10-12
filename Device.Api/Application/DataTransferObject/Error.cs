namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 错误
    /// </summary>
    public readonly record struct Error
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; init; }
    }
}