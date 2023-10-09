using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.DataTransferObject;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 更新计划查询接口
    /// </summary>
    public interface IUpdatePlanQuery
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
        /// <param name="updatePlanQueryRequest">更新计划查询请求</param>
        /// <returns></returns>
        Task<QueryResult<UpdatePlan>> QueryUpdatePlansAsync(UpdatePlanQueryRequest updatePlanQueryRequest);

        /// <summary>
        /// 异步获取更新任务
        /// </summary>
        /// <param name="updateTaskId">更新任务 Id</param>
        /// <returns></returns>
        Task<UpdateTask?> GetUpdateTaskAsync(long updateTaskId);

        /// <summary>
        /// 异步查询更新任务
        /// </summary>
        /// <param name="updateTaskQueryRequest">更新任务查询请求</param>
        /// <returns></returns>
        Task<QueryResult<UpdateTask>> QueryUpdateTasksAsync(UpdateTaskQueryRequest updateTaskQueryRequest);
    }
}