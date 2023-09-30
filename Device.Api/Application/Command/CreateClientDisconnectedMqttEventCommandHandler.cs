using Hermes.Common.IdentityGenerator;
using Hermes.Service.Device.Domain.Aggregate.MqttEventAggregate;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Command
{
    /// <summary>
    /// 创建客户端连接已断开 Mqtt 事件命令处理器
    /// </summary>
    public class CreateClientDisconnectedMqttEventCommandHandler : IRequestHandler<CreateClientDisconnectedMqttEventCommand>
    {
        /// <summary>
        /// Id 生成器
        /// </summary>
        private readonly IIdentityGenerator<long> identityGenerator;

        /// <summary>
        /// 客户端连接已断开 Mqtt 事件仓储
        /// </summary>
        private readonly IMqttEventRepository<ClientDisconnectedMqttEvent> mqttEventRepository;

        /// <summary>
        /// 实例化创建客户端连接已断开 Mqtt 事件命令处理器
        /// </summary>
        /// <param name="identityGenerator">Id 生成器</param>
        /// <param name="mqttEventRepository">客户端连接已断开 Mqtt 事件仓储</param>
        public CreateClientDisconnectedMqttEventCommandHandler(IIdentityGenerator<long> identityGenerator, IMqttEventRepository<ClientDisconnectedMqttEvent> mqttEventRepository)
        {
            this.identityGenerator = identityGenerator;
            this.mqttEventRepository = mqttEventRepository;
        }

        /// <summary>
        /// 处理命令
        /// </summary>
        /// <param name="request">创建客户端连接已断开 Mqtt 事件命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public async Task Handle(CreateClientDisconnectedMqttEventCommand request, CancellationToken cancellationToken)
        {
            var id = await identityGenerator.GetNextIdAsync();
            await mqttEventRepository.AddAsync(new ClientDisconnectedMqttEvent(id)
            {
                ClientId = request.EmqxClientDisconnectedEvent.ClientId,
                Username = request.EmqxClientDisconnectedEvent.Username,
                Timestamp = request.EmqxClientDisconnectedEvent.Timestamp,
                DisconnectedAt = request.EmqxClientDisconnectedEvent.DisconnectedAt,
                Reason = request.EmqxClientDisconnectedEvent.Reason switch
                {
                    "normal" => ClientDisconnectReason.Normal,
                    "kicked" => ClientDisconnectReason.Kicked,
                    "keepalive_timeout" => ClientDisconnectReason.KeepaliveTimeout,
                    "not_authorized" => ClientDisconnectReason.NotAuthorized,
                    "tcp_closed" => ClientDisconnectReason.TcpClosed,
                    "discarded" => ClientDisconnectReason.Discarded,
                    "takenover" => ClientDisconnectReason.Takenover,
                    "internal_error" => ClientDisconnectReason.InternalError,
                    _ => ClientDisconnectReason.Unknown
                }
            });
        }
    }
}