using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.Command;
using Hermes.Service.Device.Api.Application.DataTransferObject;
using Hermes.Service.Device.Api.Application.Query;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Hermes.Service.Device.Api.Controller
{
    /// <summary>
    /// 更新包控制器
    /// </summary>
    [Route("api/[controller]")]
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
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("update-packages")]
        public async Task<ActionResult<Response>> UploadUpdatePackageAsync([FromForm] IFormFile file)
        {
            return await mediator.Send(new UploadUpdatePackageCommand()
            {
                File = file
            });
        }

        /// <summary>
        /// 异步查询更新包枚举
        /// </summary>
        /// <param name="updatePackageQueryCommand">更新包查询命令</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<QueryResult<UpdatePackage>> QueryUpdatePackagesAsync([FromForm] UpdatePackageQueryCommand updatePackageQueryCommand)
        {
            return await updatePackageQuery.QueryUpdatePackagesAsync(updatePackageQueryCommand);
        }

        /// <summary>
        /// 异步删除更新包
        /// </summary>
        /// <param name="updatePackageId">更新包 Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<Response> DeleteUpdatePackageAsync([FromQuery] long updatePackageId)
        {
            return await mediator.Send(new DeleteUpdatePackageCommand()
            {
                UpdatePackageId = updatePackageId
            });
        }
    }
}