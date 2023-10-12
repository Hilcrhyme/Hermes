using Hermes.Service.Device.Api.Application.DataTransferObject.EmqxEvent;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands
{
    /// <summary>
    /// 创建客户端已连接 Mqtt 事件命令
    /// </summary>
    public record class CreateClientConnectedMqttEventCommand : IRequest
    {
        /// <summary>
        /// Emqx 客户端已连接事件
        /// </summary>
        public EmqxClientConnectedEvent EmqxClientConnectedEvent { get; init; }

        /// <summary>
        /// 实例化创建客户端已连接 Mqtt 事件命令
        /// </summary>
        /// <param name="emqxClientConnectedEvent">Emqx 客户端已连接事件</param>
        public CreateClientConnectedMqttEventCommand(EmqxClientConnectedEvent emqxClientConnectedEvent)
        {
            EmqxClientConnectedEvent = emqxClientConnectedEvent;
        }
    }
}