using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.DataTransferObject;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 控制计划查询接口
    /// </summary>
    public interface IControlPlanQuery
    {
        /// <summary>
        /// 异步获取控制计划
        /// </summary>
        /// <param name="controlPlanId">控制计划 Id</param>
        /// <returns></returns>
        Task<ControlPlan?> GetControlPlanAsync(long controlPlanId);

        /// <summary>
        /// 异步查询控制计划
        /// </summary>
        /// <param name="controlPlanQueryRequest">控制计划查询请求</param>
        /// <returns></returns>
        Task<QueryResult<ControlPlan>> QueryControlPlansAsync(ControlPlanQueryRequest controlPlanQueryRequest);

        /// <summary>
        /// 异步获取控制任务
        /// </summary>
        /// <param name="controlTaskId">控制任务 Id</param>
        /// <returns></returns>
        Task<ControlTask?> GetControlTaskAsync(long controlTaskId);

        /// <summary>
        /// 异步查询控制任务
        /// </summary>
        /// <param name="controlTaskQueryRequest">控制任务查询请求</param>
        /// <returns></returns>
        Task<QueryResult<ControlTask>> QueryControlTasksAsync(ControlTaskQueryRequest controlTaskQueryRequest);
    }
}