using Hermes.Common.IdentityGenerator;
using Hermes.Service.Device.Domain.Aggregates.ControlPlanAggregate;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands
{
    /// <summary>
    /// 创建控制计划命令处理器
    /// </summary>
    public class CreateControlPlanCommandHandler : IRequestHandler<CreateControlPlanCommand, long>
    {
        /// <summary>
        /// 控制计划仓储
        /// </summary>
        private readonly IControlPlanRepository controlPlanRepository;

        /// <summary>
        /// Id 生成器
        /// </summary>
        private readonly IIdentityGenerator<long> identityGenerator;

        /// <summary>
        /// 实例化控制计划仓储
        /// </summary>
        /// <param name="controlPlanRepository">控制计划仓储</param>
        /// <param name="identityGenerator">Id 生成器</param>
        public CreateControlPlanCommandHandler(IControlPlanRepository controlPlanRepository, IIdentityGenerator<long> identityGenerator)
        {
            this.controlPlanRepository = controlPlanRepository;
            this.identityGenerator = identityGenerator;
        }

        /// <summary>
        /// 异步处理创建控制计划命令
        /// </summary>
        /// <param name="request">创建控制计划命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public async Task<long> Handle(CreateControlPlanCommand request, CancellationToken cancellationToken)
        {
            var id = await identityGenerator.GetNextIdAsync();
            var plan = new ControlPlan(id, request.ControlPlanName, request.ControlPlanData, request.ControlPlanTimeout);
            foreach (var item in request.Devices)
            {
                var taskId = await identityGenerator.GetNextIdAsync();
                var task = new ControlTask(taskId, item, id);
                plan.AddControlTask(task);
            }
            await controlPlanRepository.AddAsync(plan);
            return id;
        }
    }
}