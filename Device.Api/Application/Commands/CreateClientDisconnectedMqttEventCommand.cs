using Hermes.Service.Device.Api.Application.DataTransferObject.EmqxEvent;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands
{
    /// <summary>
    /// 创建客户端连接已断开 Mqtt 事件命令
    /// </summary>
    public record CreateClientDisconnectedMqttEventCommand : IRequest
    {
        /// <summary>
        /// Emqx 客户端连接已断开事件
        /// </summary>
        public EmqxClientDisconnectedEvent EmqxClientDisconnectedEvent { get; init; }

        /// <summary>
        /// 实例化创建客户端连接已断开 Mqtt 事件命令
        /// </summary>
        /// <param name="emqxClientDisconnectedEvent">Emqx 客户端连接已断开事件</param>
        public CreateClientDisconnectedMqttEventCommand(EmqxClientDisconnectedEvent emqxClientDisconnectedEvent)
        {
            EmqxClientDisconnectedEvent = emqxClientDisconnectedEvent;
        }
    }
}