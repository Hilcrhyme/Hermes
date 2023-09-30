namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public abstract record class QueryCondition
    {
        /// <summary>
        /// 查询页大小
        /// </summary>
        public int PageSize { get; init; } = 0;

        /// <summary>
        /// 查询页页码
        /// </summary>
        public int PageNumber { get; init; } = 0;
    }
}