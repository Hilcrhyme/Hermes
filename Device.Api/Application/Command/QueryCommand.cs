namespace Hermes.Service.Device.Api.Application.Command
{
    /// <summary>
    /// 查询命令
    /// </summary>
    public abstract record class QueryCommand
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