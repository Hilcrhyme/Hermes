using Hermes.Common.IdentityGenerator;
using Hermes.Service.Device.Domain.Aggregates.UpdatePlanAggregate;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands.UpdatePlanCommands
{
    /// <summary>
    /// 创建更新计划命令处理器
    /// </summary>
    public class CreateUpdatePlanCommandHandler : IRequestHandler<CreateUpdatePlanCommand, long>
    {
        /// <summary>
        /// 更新计划仓储
        /// </summary>
        private readonly IUpdatePlanRepository updatePlanRepository;

        /// <summary>
        /// Id 生成器
        /// </summary>
        private readonly IIdentityGenerator<long> identityGenerator;

        /// <summary>
        /// 实例化创建更新计划命令处理器
        /// </summary>
        /// <param name="updatePlanRepository">更新计划仓储</param>
        /// <param name="identityGenerator">Id 生成器</param>
        public CreateUpdatePlanCommandHandler(IUpdatePlanRepository updatePlanRepository, IIdentityGenerator<long> identityGenerator)
        {
            this.updatePlanRepository = updatePlanRepository;
            this.identityGenerator = identityGenerator;
        }

        /// <summary>
        /// 异步处理
        /// </summary>
        /// <param name="request">创建更新计划命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public async Task<long> Handle(CreateUpdatePlanCommand request, CancellationToken cancellationToken)
        {
            var id = await identityGenerator.GetNextIdAsync();
            var updatePlan = new UpdatePlan(id, request.Name, request.UpdatePackageId);
            foreach (var item in request.Devices)
            {
                var updateTaskId = await identityGenerator.GetNextIdAsync();
                updatePlan.AddUpdateTask(updateTaskId, item);
            }
            await updatePlanRepository.AddAsync(updatePlan);
            return id;
        }
    }
}
