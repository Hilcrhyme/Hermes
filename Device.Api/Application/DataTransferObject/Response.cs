namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 响应
    /// </summary>
    public record class Response
    {
        /// <summary>
        /// 响应结果
        /// </summary>
        public bool Result { get; init; } = false;

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; init; } = string.Empty;
    }

    /// <summary>
    /// 响应
    /// </summary>
    /// <typeparam name="T">响应数据的类型</typeparam>
    public record class Response<T> : Response
    {
        /// <summary>
        /// 响应数据
        /// </summary>
        public T Data { get; init; } = default!;
    }
}