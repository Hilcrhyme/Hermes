using Hermes.Service.Device.Api.Application.DataTransferObject;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Command
{
    /// <summary>
    /// 删除更新包命令
    /// </summary>
    public readonly record struct DeleteUpdatePackageCommand : IRequest<Response>
    {
        /// <summary>
        /// 更新包 Id
        /// </summary>
        public long UpdatePackageId { get; init; }
    }
}