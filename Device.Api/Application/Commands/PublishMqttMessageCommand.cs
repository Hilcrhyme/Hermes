using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands
{
    /// <summary>
    /// 发布 Mqtt 消息命令
    /// </summary>
    public class PublishMqttMessageCommand : IRequest
    {
        /// <summary>
        /// 要发布的主题
        /// </summary>
        public string Topic { get; init; } = string.Empty;

        /// <summary>
        /// 消息负载
        /// </summary>
        public Memory<byte> Payload { get; init; } = new Memory<byte>();

        /// <summary>
        /// 保留消息标志
        /// </summary>
        public bool RetainFlag { get; init; } = false;
    }
}