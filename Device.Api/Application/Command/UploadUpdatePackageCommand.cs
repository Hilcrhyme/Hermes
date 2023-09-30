using Hermes.Service.Device.Api.Application.DataTransferObject;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Command
{
    /// <summary>
    /// 上传更新包命令
    /// </summary>
    public readonly record struct UploadUpdatePackageCommand : IRequest<Response>
    {
        /// <summary>
        /// 文件
        /// </summary>
        public IFormFile File { get; init; }
    }
}