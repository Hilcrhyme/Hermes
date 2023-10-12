using Hermes.Service.Device.Api.Application.DataTransferObject;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands
{
    /// <summary>
    /// 删除更新包命令
    /// </summary>
    public readonly record struct DeleteUpdatePackageCommand : IRequest<bool>
    {
        /// <summary>
        /// 更新包 Id
        /// </summary>
        public long UpdatePackageId { get; init; }
    }
}