using Hermes.Service.Device.Api.Application.DataTransferObject;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Command
{
    /// <summary>
    /// 上传更新包命令处理器
    /// </summary>
    public class UploadUpdatePackageCommandHandler : IRequestHandler<UploadUpdatePackageCommand, Response>
    {
        /// <summary>
        /// 异步处理上传更新包命令
        /// </summary>
        /// <param name="request">上传更新包命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public async Task<Response> Handle(UploadUpdatePackageCommand request, CancellationToken cancellationToken)
        {
            try
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
                return new Response()
                {
                    Result = true,
                    Message = "上传成功！"
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    Result = false,
                    Message = ex.Message
                };
            }
        }
    }
}
