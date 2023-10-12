namespace Hermes.Common.SeedWork
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="T">仓储数据的类型</typeparam>
    public interface IRepository<T> where T : IAggregateRoot
    {
        /// <summary>
        /// 工作单元
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 异步新增实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public Task<T> AddAsync(T entity);

        /// <summary>
        /// 异步移除实体
        /// </summary>
        /// <param name="id">实体 Id</param>
        /// <returns></returns>
        public Task RemoveAsync(long id);

        /// <summary>
        /// 异步更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public Task<T> UpdateAsync(T entity);

        /// <summary>
        /// 异步获取实体
        /// </summary>
        /// <param name="id">实体 Id</param>
        /// <returns></returns>
        public Task<T?> GetAsync(long id);

        /// <summary>
        /// 异步查询
        /// </summary>
        /// <param name="options">查询选项</param>
        /// <returns></returns>
        public Task<QueryResult<T>> QueryAsync(QueryOptions<T> options);
    }
}