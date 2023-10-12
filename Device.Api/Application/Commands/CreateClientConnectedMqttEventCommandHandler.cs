using Hermes.Common.IdentityGenerator;
using Hermes.Service.Device.Domain.Aggregates.DeviceAggregate;
using Hermes.Service.Device.Domain.Aggregates.MqttEventAggregate;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands
{
    /// <summary>
    /// 创建客户端已连接 Mqtt 事件命令处理器
    /// </summary>
    public class CreateClientConnectedMqttEventCommandHandler : IRequestHandler<CreateClientConnectedMqttEventCommand>
    {
        /// <summary>
        /// Id 生成器
        /// </summary>
        private readonly IIdentityGenerator<long> identityGenerator;

        /// <summary>
        /// 客户端已连接 Mqtt 事件仓储
        /// </summary>
        private readonly IMqttEventRepository<ClientConnectedMqttEvent> mqttEventRepository;

        /// <summary>
        /// 设备领域服务
        /// </summary>
        private readonly IDeviceDomainService deviceDomainService;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<CreateClientConnectedMqttEventCommandHandler> logger;

        /// <summary>
        /// 实例化创建客户端已连接 Mqtt 事件命令处理器
        /// </summary>
        /// <param name="identityGenerator">Id 生成器</param>
        /// <param name="mqttEventRepository">客户端已连接 Mqtt 事件仓储</param>
        /// <param name="deviceDomainService">设备领域服务</param>
        /// <param name="logger">日志器</param>
        public CreateClientConnectedMqttEventCommandHandler(IIdentityGenerator<long> identityGenerator, IMqttEventRepository<ClientConnectedMqttEvent> mqttEventRepository, IDeviceDomainService deviceDomainService, ILogger<CreateClientConnectedMqttEventCommandHandler> logger)
        {
            this.identityGenerator = identityGenerator;
            this.mqttEventRepository = mqttEventRepository;
            this.deviceDomainService = deviceDomainService;
            this.logger = logger;
        }

        /// <summary>
        /// 处理命令
        /// </summary>
        /// <param name="request">创建客户端已连接 Mqtt 事件命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public async Task Handle(CreateClientConnectedMqttEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var id = await identityGenerator.GetNextIdAsync();
                await mqttEventRepository.AddAsync(new ClientConnectedMqttEvent(id)
                {
                    ClientId = request.EmqxClientConnectedEvent.ClientId,
                    Username = request.EmqxClientConnectedEvent.Username,
                    Timestamp = request.EmqxClientConnectedEvent.Timestamp,
                    ConnectedAt = request.EmqxClientConnectedEvent.ConnectedAt
                });
                await deviceDomainService.ConnectByMqttConnectionAsync(request.EmqxClientConnectedEvent.ClientId);
            }
            catch (Exception ex)
            {
                logger.LogCritical();
            }
        }
    }
}