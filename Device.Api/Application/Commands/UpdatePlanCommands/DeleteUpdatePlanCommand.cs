using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands.UpdatePlanCommands
{
    /// <summary>
    /// 删除更新计划命令
    /// </summary>
    public readonly record struct DeleteUpdatePlanCommand : IRequest
    {
        /// <summary>
        /// 更新计划 Id
        /// </summary>
        public long UpdatePlanId { get; init; }
    }
}