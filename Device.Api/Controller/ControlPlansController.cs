using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.DataTransferObject;
using Hermes.Service.Device.Api.Application.Query;

using Microsoft.AspNetCore.Mvc;

namespace Hermes.Service.Device.Api.Controller
{
    /// <summary>
    /// 控制计划控制器
    /// </summary>
    [Route("api/control-plans")]
    [ApiController]
    public class ControlPlansController : ControllerBase
    {
        /// <summary>
        /// 控制计划查询
        /// </summary>
        private readonly IControlPlanQuery controlPlanQuery;

        /// <summary>
        /// 实例化控制计划控制器
        /// </summary>
        /// <param name="controlPlanQuery">控制计划查询</param>
        public ControlPlansController(IControlPlanQuery controlPlanQuery)
        {
            this.controlPlanQuery = controlPlanQuery;
        }

        /// <summary>
        /// 异步获取控制计划
        /// </summary>
        /// <param name="controlPlanId">控制计划 Id</param>
        /// <returns></returns>
        [HttpGet("{controlPlanId}:long")]
        public async Task<ActionResult<ControlPlan?>> GetControlPlanAsync([FromRoute] long controlPlanId)
        {
            var plan = await controlPlanQuery.GetControlPlanAsync(controlPlanId);
            if (plan is null)
            {
                return NotFound();
            }
            return plan;
        }

        /// <summary>
        /// 异步查询控制计划
        /// </summary>
        /// <param name="updatePlanQueryRequest">更新计划查询请求</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<QueryResult<ControlPlan>>> QueryControlPlansAsync([FromQuery] UpdatePlanQueryRequest updatePlanQueryRequest)
        {
            return await updatePlanQuery.QueryUpdatePlansAsync(updatePlanQueryRequest);
        }

        /// <summary>
        /// 异步获取控制任务
        /// </summary>
        /// <param name="controlTaskId">控制任务 Id</param>
        /// <returns></returns>
        [HttpGet("control-tasks/{controlTaskId:long}")]
        public async Task<ActionResult<ControlTask?>> GetControlTaskAsync([FromRoute] long controlTaskId)
        {
            return await controlPlanQuery.GetControlTaskAsync(controlTaskId);
        }

        /// <summary>
        /// 异步获取控制任务枚举
        /// </summary>
        /// <param name="controlPlanId">控制计划 Id</param>
        /// <returns></returns>
        [HttpGet("{controlPlanId}:long/control-tasks")]
        public async Task<ActionResult<IEnumerable<ControlTask>>> GetControlTasksAsync([FromRoute] long controlPlanId)
        {
            var plan = await controlPlanQuery.GetControlPlanAsync(controlPlanId);
            if (plan is null)
            {
                return NotFound();
            }
            return Ok(plan.Value.ControlTasks);
        }

        /// <summary>
        /// 异步查询控制任务
        /// </summary>
        /// <param name="updateTaskQueryRequest">更新任务查询请求</param>
        /// <returns></returns>
        [HttpGet("control-tasks")]
        public async Task<ActionResult<QueryResult<ControlTask>>> QueryControlTasksAsync([FromQuery] UpdateTaskQueryRequest updateTaskQueryRequest)
        {
            return await updatePlanQuery.QueryUpdateTasksAsync(updateTaskQueryRequest);
        }
    }
}