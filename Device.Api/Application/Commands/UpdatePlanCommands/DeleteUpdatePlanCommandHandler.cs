using Hermes.Service.Device.Domain.Aggregates.UpdatePlanAggregate;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands.UpdatePlanCommands
{
    /// <summary>
    /// 删除更新计划命令处理器
    /// </summary>
    public class DeleteUpdatePlanCommandHandler : IRequestHandler<DeleteUpdatePlanCommand>
    {
        /// <summary>
        /// 更新计划仓储
        /// </summary>
        private readonly IUpdatePlanRepository updatePlanRepository;

        /// <summary>
        /// 实例化删除更新计划命令处理器
        /// </summary>
        /// <param name="updatePlanRepository">更新计划仓储</param>
        public DeleteUpdatePlanCommandHandler(IUpdatePlanRepository updatePlanRepository)
        {
            this.updatePlanRepository = updatePlanRepository;
        }

        /// <summary>
        /// 异步处理删除更新计划命令
        /// </summary>
        /// <param name="request">删除更新计划命令</param>
        /// <param name="cancellationToken">删除更新计划命令的取消令牌</param>
        /// <returns></returns>
        public async Task Handle(DeleteUpdatePlanCommand request, CancellationToken cancellationToken)
        {
            await updatePlanRepository.RemoveAsync(request.UpdatePlanId);
        }
    }
}