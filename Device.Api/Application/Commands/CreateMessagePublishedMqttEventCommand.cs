using Hermes.Service.Device.Api.Application.DataTransferObject.EmqxEvent;
using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands
{
    /// <summary>
    /// 创建消息已发布 Mqtt 事件命令
    /// </summary>
    public record CreateMessagePublishedMqttEventCommand : IRequest
    {
        /// <summary>
        /// Emqx 消息已发布事件
        /// </summary>
        public EmqxMessagePublishedEvent EmqxMessagePublishedEvent { get; init; }

        /// <summary>
        /// 实例化创建消息已发布 Mqtt 事件命令
        /// </summary>
        /// <param name="emqxMessagePublishedEvent">Emqx 消息已发布事件</param>
        public CreateMessagePublishedMqttEventCommand(EmqxMessagePublishedEvent emqxMessagePublishedEvent)
        {
            EmqxMessagePublishedEvent = emqxMessagePublishedEvent;
        }
    }
}
