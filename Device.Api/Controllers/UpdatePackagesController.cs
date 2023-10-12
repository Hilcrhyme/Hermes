using Hermes.Common.Extension;
using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.Commands;
using Hermes.Service.Device.Api.Application.DataTransferObject;
using Hermes.Service.Device.Api.Application.Query;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Hermes.Service.Device.Api.Controllers
{
    /// <summary>
    /// 更新包控制器
    /// </summary>
    [Route("api/update-packages")]
    [ApiController]
    public class UpdatePackagesController : ControllerBase
    {
        /// <summary>
        /// 消息中介器
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// 更新包查询
        /// </summary>
        private readonly IUpdatePackageQuery updatePackageQuery;

        /// <summary>
        /// 消息中介器
        /// </summary>
        /// <param name="mediator">消息中介器</param>
        /// <param name="updatePackageQuery">更新包查询</param>
        public UpdatePackagesController(IMediator mediator, IUpdatePackageQuery updatePackageQuery)
        {
            this.mediator = mediator;
            this.updatePackageQuery = updatePackageQuery;
        }

        /// <summary>
        /// 异步上传更新包
        /// </summary>
        /// <param name="file">更新包文件</param>
        /// <returns></returns>
        [HttpPost("update-packages")]
        public async Task<ActionResult> UploadUpdatePackageAsync([FromForm] IFormFile file)
        {
            try
            {
                await mediator.Send(new UploadUpdatePackageCommand()
                {
                    File = file
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
        /// 异步删除更新包
        /// </summary>
        /// <param name="updatePackageId">更新包 Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteUpdatePackageAsync([FromQuery] long updatePackageId)
        {
            try
            {
                await mediator.Send(new DeleteUpdatePackageCommand()
                {
                    UpdatePackageId = updatePackageId
                });
                return NoContent();
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
        /// 异步查询更新包
        /// </summary>
        /// <param name="updatePackageQueryRequest">更新包查询请求</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<QueryResult<UpdatePackage>> QueryUpdatePackagesAsync([FromForm] UpdatePackageQueryRequest updatePackageQueryRequest)
        {
            return await updatePackageQuery.QueryUpdatePackagesAsync(updatePackageQueryRequest);
        }
    }
}