using Hermes.Service.Device.Domain.Aggregate.UpdateTaskAggregate;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 更新任务查询接口
    /// </summary>
    public interface IUpdateTaskQuery
    {
        /// <summary>
        /// 异步获取更新子任务
        /// </summary>
        /// <param name="subUpdateTaskId">更新子任务 Id</param>
        /// <returns></returns>
        Task<SubUpdateTask?> GetSubUpdateTaskAsync(long subUpdateTaskId);
    }
}