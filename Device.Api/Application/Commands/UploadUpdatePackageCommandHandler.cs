using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands
{
    /// <summary>
    /// 上传更新包命令处理器
    /// </summary>
    public class UploadUpdatePackageCommandHandler : IRequestHandler<UploadUpdatePackageCommand>
    {
        /// <summary>
        /// 异步处理上传更新包命令
        /// </summary>
        /// <param name="request">上传更新包命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public async Task Handle(UploadUpdatePackageCommand request, CancellationToken cancellationToken)
        {
            var directory = Path.Combine(AppContext.BaseDirectory, "update-packages");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var fileName = $"{Guid.NewGuid()}_{Path.GetExtension(request.File.FileName)}";
            var filePath = Path.Combine(directory, fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await request.File.CopyToAsync(stream, cancellationToken);
        }
    }
}