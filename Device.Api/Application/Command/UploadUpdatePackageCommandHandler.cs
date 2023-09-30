using Hermes.Service.Device.Api.Application.DataTransferObject;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Command
{
    /// <summary>
    /// 上传更新包命令处理器
    /// </summary>
    public class UploadUpdatePackageCommandHandler : IRequestHandler<UploadUpdatePackageCommand, Response>
    {
        public Task<Response> Handle(UploadUpdatePackageCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
