﻿using Hermes.Service.Device.Api.Application.Command;
using Hermes.Service.Device.Api.Application.DataTransferObject.EmqxEvent;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Hermes.Service.Device.Api.Controller
{
    /// <summary>
    /// Emqx 事件控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmqxEventsController : ControllerBase
    {
        /// <summary>
        /// 消息中介器
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// 实例化 Mqtt 事件控制器
        /// </summary>
        /// <param name="mediator">消息中介器</param>
        public EmqxEventsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// 异步保存 Emqx 客户端已连接事件
        /// </summary>
        /// <param name="clientConnectedEvent">Emqx 客户端已连接事件</param>
        /// <returns></returns>
        [HttpPost("client-connected-event")]
        public async Task<IActionResult> SaveEmqxClientConnectedEventAsync([FromBody] EmqxClientConnectedEvent clientConnectedEvent)
        {
            await mediator.Send(new CreateClientConnectedMqttEventCommand(clientConnectedEvent));
            return Ok();
        }

        /// <summary>
        /// 异步保存 Emqx 客户端连接已断开事件
        /// </summary>
        /// <param name="clientDisconnectedEvent">Emqx 客户端连接已断开事件</param>
        /// <returns></returns>
        [HttpPost("client-disconnected-event")]
        public async Task<IActionResult> SaveEmqxClientDisconnectedEventAsync([FromBody] EmqxClientDisconnectedEvent clientDisconnectedEvent)
        {
            await mediator.Send(new CreateClientDisconnectedMqttEventCommand(clientDisconnectedEvent));
            return Ok();
        }

        /// <summary>
        /// 异步保存 Emqx 消息已发布事件
        /// </summary>
        /// <param name="messagePublishedEvent">Emqx 消息已发布事件</param>
        /// <returns></returns>
        [HttpPost("message-published-event")]
        public async Task<IActionResult> SaveEmqxMessagePublishedEventAsync([FromBody] EmqxMessagePublishedEvent messagePublishedEvent)
        {
            await mediator.Send(new CreateMessagePublishedMqttEventCommand(messagePublishedEvent));
            return Ok();
        }
    }
}