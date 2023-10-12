using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.Commands;
using Hermes.Service.Device.Api.Application.DataTransferObject;
using Hermes.Service.Device.Api.Application.Query;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Hermes.Service.Device.Api.Controllers
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
        /// 消息中介器
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// 实例化控制计划控制器
        /// </summary>
        /// <param name="controlPlanQuery">控制计划查询</param>
        /// <param name="mediator">消息中介器</param>
        public ControlPlansController(IControlPlanQuery controlPlanQuery, IMediator mediator)
        {
            this.controlPlanQuery = controlPlanQuery;
            this.mediator = mediator;
        }

        /// <summary>
        /// 异步创建控制计划
        /// </summary>
        /// <param name="createControlPlanCommand">创建控制计划命令</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<long?>> CreateControlPlanAsync([FromBody] CreateControlPlanCommand createControlPlanCommand)
        {
            return await mediator.Send(createControlPlanCommand);
        }

        /// <summary>
        /// 异步删除控制计划
        /// </summary>
        /// <param name="controlPlanId"></param>
        /// <returns></returns>
        [HttpDelete("{controlPlanId:long}")]
        public async Task<ActionResult> DeleteControlPlanAsync(long controlPlanId)
        {
            await mediator.Send(new DeleteControlPlanCommand()
            {
                ControlPlanId = controlPlanId
            });
            return NoContent();
        }

        /// <summary>
        /// 异步获取控制计划
        /// </summary>
        /// <param name="controlPlanId">控制计划 Id</param>
        /// <returns></returns>
        [HttpGet("{controlPlanId:long}")]
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
        /// <param name="controlPlanQueryRequest">控制计划查询请求</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<QueryResult<ControlPlan>>> QueryControlPlansAsync([FromQuery] ControlPlanQueryRequest controlPlanQueryRequest)
        {
            return await controlPlanQuery.QueryControlPlansAsync(controlPlanQueryRequest);
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
        [HttpGet("{controlPlanId:long}/control-tasks")]
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
        /// <param name="controlTaskQueryRequest">控制任务查询请求</param>
        /// <returns></returns>
        [HttpGet("control-tasks")]
        public async Task<ActionResult<QueryResult<ControlTask>>> QueryControlTasksAsync([FromQuery] ControlTaskQueryRequest controlTaskQueryRequest)
        {
            return await controlPlanQuery.QueryControlTasksAsync(controlTaskQueryRequest);
        }
    }
}