namespace Hermes.Common.SeedWork
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 异步保存实体
        /// </summary>
        /// <param name="cancellationToken">保存实体的取消令牌</param>
        /// <returns></returns>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}