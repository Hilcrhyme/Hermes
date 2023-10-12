using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands.UpdatePlanCommands
{
    /// <summary>
    /// 取消更新计划命令处理器
    /// </summary>
    public class CancelUpdatePlanCommandHandler : IRequestHandler<CancelUpdatePlanCommand>
    {


        public Task Handle(CancelUpdatePlanCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}