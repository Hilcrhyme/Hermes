using Hermes.Common.Extension;
using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.Commands.UpdatePlanCommands;
using Hermes.Service.Device.Api.Application.DataTransferObject;
using Hermes.Service.Device.Api.Application.Query;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Hermes.Service.Device.Api.Controllers
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
        /// 消息中介器
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// 实例化更新计划控制器
        /// </summary>
        /// <param name="updatePlanQuery">更新计划仓储</param>
        /// <param name="mediator">消息中介器</param>
        public UpdatePlansController(IUpdatePlanQuery updatePlanQuery, IMediator mediator)
        {
            this.updatePlanQuery = updatePlanQuery;
            this.mediator = mediator;
        }

        /// <summary>
        /// 异步创建更新计划
        /// </summary>
        /// <param name="createUpdatePlanCommand">创建更新计划命令</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<long>> CreateUpdatePlanAsync([FromBody] CreateUpdatePlanCommand createUpdatePlanCommand)
        {
            try
            {
                return Ok(await mediator.Send(createUpdatePlanCommand));
            }
            catch (Exception ex)
            {
                return this.InternalServerError(new Error()
                {
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// 异步取消更新计划
        /// </summary>
        /// <param name="updatePlanId">更新计划 Id</param>
        /// <returns></returns>
        [HttpPatch("{updatePlanId:long}")]
        public async Task<ActionResult> CancelUpdatePlanAsync([FromRoute] long updatePlanId)
        {
            try
            {
                await mediator.Send(new CancelUpdatePlanCommand()
                {
                    UpdatePlanId = updatePlanId
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return this.InternalServerError(new Error()
                {
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// 异步删除更新计划
        /// </summary>
        /// <param name="updatePlanId">更新计划 Id</param>
        /// <returns></returns>
        [HttpDelete("{updatePlanId:long}")]
        public async Task<ActionResult> DeleteUpdatePlanAsync([FromRoute] long updatePlanId)
        {
            try
            {
                await mediator.Send(new DeleteUpdatePlanCommand()
                {
                    UpdatePlanId = updatePlanId
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return this.InternalServerError(new Error()
                {
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// 异步获取更新计划
        /// </summary>
        /// <param name="updatePlanId">更新计划 Id</param>
        /// <returns></returns>
        [HttpGet("{updatePlanId:long}")]
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
        [HttpGet("{updatePlanId:long}/update-tasks")]
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