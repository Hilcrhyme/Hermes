namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 查询请求
    /// </summary>
    public abstract record class QueryRequest
    {
        /// <summary>
        /// 查询的当前页码
        /// </summary>
        public int? PageNumber { get; init; } = 0;

        /// <summary>
        /// 查询的每页结果数量
        /// </summary>
        public int? PageSize { get; init; } = 0;
    }
}