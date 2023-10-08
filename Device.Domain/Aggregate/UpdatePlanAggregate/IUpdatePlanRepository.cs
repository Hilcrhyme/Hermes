using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.UpdatePlanAggregate
{
    /// <summary>
    /// 更新计划仓储接口
    /// </summary>
    public interface IUpdatePlanRepository : IRepository<UpdatePlan>
    {
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