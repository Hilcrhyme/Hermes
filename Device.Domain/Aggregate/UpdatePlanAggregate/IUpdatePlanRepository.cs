using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.UpdatePlanAggregate
{
    /// <summary>
    /// 更新计划仓储接口
    /// </summary>
    public interface IUpdatePlanRepository : IRepository<UpdatePlan>
    {
        /// <summary>
        /// 异步获取更新计划
        /// </summary>
        /// <param name="updatePlanId">更新计划 Id</param>
        /// <returns></returns>
        Task<UpdatePlan?> GetUpdatePlanAsync(long updatePlanId);

        /// <summary>
        /// 异步查询更新计划
        /// </summary>
        /// <param name="options">更新计划查询选项</param>
        /// <returns></returns>
        Task<QueryResult<UpdatePlan>> QueryUpdatePlanAsync(QueryOptions<UpdatePlan> options);

        /// <summary>
        /// 异步获取更新任务
        /// </summary>
        /// <param name="updateTaskId">更新任务 Id</param>
        /// <returns></returns>
        Task<UpdateTask?> GetUpdateTaskAsync(long updateTaskId);

        /// <summary>
        /// 异步查询更新任务
        /// </summary>
        /// <param name="options">更新任务查询选项</param>
        /// <returns></returns>
        Task<QueryResult<UpdateTask>> QueryUpdateTaskAsync(QueryOptions<UpdateTask> options);

        /// <summary>
        /// 异步同步更新进度
        /// </summary>
        /// <param name="updateTaskId">更新任务 Id</param>
        /// <param name="value">进度值</param>
        /// <param name="message">消息</param>
        /// <param name="synchronizedTime">同步时间</param>
        /// <returns></returns>
        Task SynchronizeUpdateProgressAsync(long updateTaskId, int value, string message, DateTime synchronizedTime);
    }
}