using Hermes.Service.Device.Api.Application.Command;
using Hermes.Service.Device.Api.Application.DataTransferObject;

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
        /// 消息中介器
        /// </summary>
        /// <param name="mediator"></param>
        public UpdatePackagesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// 异步上传更新包
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("update-packages")]
        public async Task<ActionResult<Response>> UploadUpdatePackageAsync([FromForm] IFormFile file)
        {
            var directory = Path.Combine(AppContext.BaseDirectory, "update-packages");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var fileName = $"{Guid.NewGuid()}_{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(directory, fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return await mediator.Send(new UploadUpdatePackageCommand()
            {
                File = file
            });
        }
    }
}