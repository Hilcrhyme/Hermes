namespace Hermes.Common.SeedWork
{
    /// <summary>
    /// 查询结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryResult<T>
    {
        /// <summary>
        /// 结果总数
        /// </summary>
        public int TotalCount { get; init; } = 0;

        /// <summary>
        /// 结果枚举
        /// </summary>
        public IEnumerable<T> Items { get; init; } = Enumerable.Empty<T>();
    }
}