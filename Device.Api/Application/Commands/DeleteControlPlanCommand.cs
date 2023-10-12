using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands
{
    /// <summary>
    /// 删除控制计划命令
    /// </summary>
    public readonly record struct DeleteControlPlanCommand : IRequest
    {
        /// <summary>
        /// 控制计划 Id
        /// </summary>
        public long ControlPlanId { get; init; }
    }
}