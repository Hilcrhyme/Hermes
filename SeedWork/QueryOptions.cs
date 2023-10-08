using System.Linq.Expressions;

namespace Hermes.Common.SeedWork
{
    /// <summary>
    /// 查询选项
    /// </summary>
    public record struct QueryOptions<T>
    {
        /// <summary>
        /// 过滤器
        /// </summary>
        public Expression<Func<T, bool>> Filter { get; set; }

        /// <summary>
        /// 排序依据
        /// </summary>
        public Expression<Func<T, object>> SortBy { get; set; }

        /// <summary>
        /// 排序方向
        /// </summary>
        public SortDirection SortDirection { get; set; }

        /// <summary>
        /// 查询的当前页码
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// 查询的每页结果数量
        /// </summary>
        public int? PageSize { get; set; }
    }
}