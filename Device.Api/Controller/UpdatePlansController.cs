using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.DataTransferObject;
using Hermes.Service.Device.Api.Application.Query;

using Microsoft.AspNetCore.Mvc;

namespace Hermes.Service.Device.Api.Controller
{
    /// <summary>
    /// 更新计划控制器
    /// </summary>
    [Route("api/update-plans")]
    [ApiController]
    public class UpdatePlansController : ControllerBase
    {
        /// <summary>
        /// 更新计划仓储
        /// </summary>
        private readonly IUpdatePlanQuery updatePlanQuery;

        /// <summary>
        /// 实例化更新计划控制器
        /// </summary>
        /// <param name="updatePlanQuery">更新计划仓储</param>
        public UpdatePlansController(IUpdatePlanQuery updatePlanQuery)
        {
            this.updatePlanQuery = updatePlanQuery;
        }

        /// <summary>
        /// 异步创建更新计划
        /// </summary>
        /// <param name="updatePlan">更新计划</param>
        /// <returns></returns>
        [HttpPost]
        public Task<ActionResult<long>> CreateUpdatePlanAsync([FromBody] UpdatePlan updatePlan)
        {
            
        }

        /// <summary>
        /// 异步获取更新计划
        /// </summary>
        /// <param name="updatePlanId">更新计划 Id</param>
        /// <returns></returns>
        [HttpGet("{updatePlanId}:long")]
        public async Task<ActionResult<UpdatePlan?>> GetUpdatePlanAsync([FromRoute] long updatePlanId)
        {
            var plan = await updatePlanQuery.GetUpdatePlanAsync(updatePlanId);
            if (plan is null)
            {
                return NotFound();
            }
            return plan;
        }

        /// <summary>
        /// 异步查询更新计划
        /// </summary>
        /// <param name="updatePlanQueryRequest">更新计划查询请求</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<QueryResult<UpdatePlan>>> QueryUpdatePlansAsync([FromQuery] UpdatePlanQueryRequest updatePlanQueryRequest)
        {
            return await updatePlanQuery.QueryUpdatePlansAsync(updatePlanQueryRequest);
        }

        /// <summary>
        /// 异步获取更新任务
        /// </summary>
        /// <param name="updateTaskId">更新任务 Id</param>
        /// <returns></returns>
        [HttpGet("update-tasks/{updateTaskId:long}")]
        public async Task<ActionResult<UpdateTask?>> GetUpdateTaskAsync([FromRoute] long updateTaskId)
        {
            return await updatePlanQuery.GetUpdateTaskAsync(updateTaskId);
        }

        /// <summary>
        /// 异步获取更新任务枚举
        /// </summary>
        /// <param name="updatePlanId">更新计划 Id</param>
        /// <returns></returns>
        [HttpGet("{updatePlanId}:long/update-tasks")]
        public async Task<ActionResult<IEnumerable<UpdateTask>>> GetUpdateTasksAsync([FromRoute] long updatePlanId)
        {
            var plan = await updatePlanQuery.GetUpdatePlanAsync(updatePlanId);
            if (plan is null)
            {
                return NotFound();
            }
            return Ok(plan.Value.UpdateTasks);
        }

        /// <summary>
        /// 异步查询更新任务
        /// </summary>
        /// <param name="updateTaskQueryRequest">更新任务查询请求</param>
        /// <returns></returns>
        [HttpGet("update-tasks")]
        public async Task<ActionResult<QueryResult<UpdateTask>>> QueryUpdateTasksAsync([FromQuery] UpdateTaskQueryRequest updateTaskQueryRequest)
        {
            return await updatePlanQuery.QueryUpdateTasksAsync(updateTaskQueryRequest);
        }
    }
}