using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands
{
    /// <summary>
    /// 通信命令处理器
    /// </summary>
    /// <typeparam name="T">通信命令的类型</typeparam>
    public abstract class CommunicationCommandHandler<T> : IRequestHandler<T> where T : CommunicationCommand
    {
        /// <summary>
        /// 异步处理通信命令
        /// </summary>
        /// <param name="request">通信命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public abstract Task Handle(T request, CancellationToken cancellationToken);
    }
}