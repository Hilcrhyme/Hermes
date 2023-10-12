using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands
{
    /// <summary>
    /// 上传更新包命令
    /// </summary>
    public readonly record struct UploadUpdatePackageCommand : IRequest
    {
        /// <summary>
        /// 文件
        /// </summary>
        public IFormFile File { get; init; }
    }
}