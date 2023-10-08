namespace Hermes.Common.SeedWork
{
    /// <summary>
    /// 查询结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly record struct QueryResult<T>
    {
        /// <summary>
        /// 结果总数
        /// </summary>
        public int TotalCount { get; init; }

        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageNumber { get; init; }

        /// <summary>
        /// 每页结果数量
        /// </summary>
        public int PageSize { get; init; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        /// <summary>
        /// 结果枚举
        /// </summary>
        public IEnumerable<T> Items { get; init; }
    }
}