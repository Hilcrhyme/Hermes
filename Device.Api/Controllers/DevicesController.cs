using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.DataTransferObject;
using Hermes.Service.Device.Api.Application.Query;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Hermes.Service.Device.Api.Controllers
{
    /// <summary>
    /// 设备管理器
    /// </summary>
    [Route("api/devices")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        /// <summary>
        /// 设备查询
        /// </summary>
        private readonly IDeviceQuery deviceQuery;

        /// <summary>
        /// 更新计划查询
        /// </summary>
        private readonly IUpdatePlanQuery updatePlanQuery;

        /// <summary>
        /// 消息中介器
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// 实例化设备管理器
        /// </summary>
        /// <param name="deviceQuery">设备查询</param>
        /// <param name="updatePlanQuery">更新计划查询</param>
        /// <param name="mediator">消息中介器</param>
        public DevicesController(IDeviceQuery deviceQuery, IUpdatePlanQuery updatePlanQuery, IMediator mediator)
        {
            this.deviceQuery = deviceQuery;
            this.updatePlanQuery = updatePlanQuery;
            this.mediator = mediator;
        }

        /// <summary>
        /// 异步查询设备
        /// </summary>
        /// <param name="deviceQueryRequest">设备查询请求</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<QueryResult<Application.DataTransferObject.Device>>> QueryDevicesAsync([FromQuery] DeviceQueryRequest deviceQueryRequest)
        {
            return await deviceQuery.QueryDevicesAsync(deviceQueryRequest);
        }

        /// <summary>
        /// 异步查询设备日志
        /// </summary>
        /// <param name="deviceId">设备 Id</param>
        /// <param name="deviceLogQueryRequest">设备日志查询请求</param>
        /// <returns></returns>
        [HttpGet("{deviceId:long}/logs")]
        public async Task<ActionResult<QueryResult<DeviceLog>>> GetDeviceLogsAsync([FromRoute] long deviceId, [FromQuery] DeviceLogQueryRequest deviceLogQueryRequest)
        {
            return await deviceQuery.QueryDeviceLogsAsync(deviceId, deviceLogQueryRequest);
        }
    }
}