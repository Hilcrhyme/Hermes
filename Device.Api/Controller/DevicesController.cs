using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.Command;
using Hermes.Service.Device.Api.Application.DataTransferObject;
using Hermes.Service.Device.Api.Application.Query;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Hermes.Service.Device.Api.Controller
{
    /// <summary>
    /// 设备管理器
    /// </summary>
    [Route("api/query/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        /// <summary>
        /// 设备查询
        /// </summary>
        private readonly IDeviceQuery deviceQuery;

        /// <summary>
        /// 消息中介器
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// 实例化设备管理器
        /// </summary>
        /// <param name="deviceQuery">设备查询</param>
        /// <param name="mediator">消息中介器</param>
        public DevicesController(IDeviceQuery deviceQuery, IMediator mediator)
        {
            this.deviceQuery = deviceQuery;
            this.mediator = mediator;
        }

        /// <summary>
        /// 异步查询设备
        /// </summary>
        /// <param name="deviceQueryCondition">设备查询条件</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<QueryResult<Application.DataTransferObject.Device>>> QueryDevicesAsync([FromQuery] DeviceQueryCondition deviceQueryCondition)
        {
            return await deviceQuery.QueryDevicesAsync(deviceQueryCondition);
        }

        /// <summary>
        /// 异步获取设备日志枚举
        /// </summary>
        /// <param name="deviceId">设备 Id</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [HttpGet("{deviceId:long}/logs")]
        public async Task<ActionResult<QueryResult<DeviceLog>>> GetDeviceLogsAsync([FromRoute] long deviceId, [FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
        {
            return await deviceQuery.QueryDeviceLogsAsync(deviceId, startTime, endTime);
        }

        /// <summary>
        /// 异步获取软件更新任务枚举
        /// </summary>
        /// <param name="deviceId">设备 Id</param>
        /// <returns></returns>
        [HttpGet("{deviceId:long}/software-update-tasks")]
        public async Task<ActionResult<QueryResult<SoftwareUpdateTask>>> GetSoftwareUpdateTask([FromRoute] long deviceId)
        {
            return await deviceQuery.GetSoftwareUpdateTasksAsync(deviceId);
        }

        /// <summary>
        /// 异步创建设备控制任务
        /// </summary>
        /// <param name="deviceId">设备 Id</param>
        /// <param name="task">设备控制任务</param>
        /// <returns></returns>
        [HttpPost("{deviceId:long}/software-update-tasks")]
        public async Task<ActionResult<Response>> CreateDeviceControlTaskAsync([FromRoute] long deviceId, [FromBody] DeviceControlTask task)
        {
            return await mediator.Send(new CreateDeviceControlTaskCommand()
            {
                Devices = new long[] { deviceId },
                TaskData = task.Data,
                TaskTimeout = task.Timeout
            });
        }

        /// <summary>
        /// 异步查询设备控制任务
        /// </summary>
        /// <param name="deviceId">设备 Id</param>
        /// <returns></returns>
        [HttpGet("{deviceId:long}/device-control-tasks")]
        public async Task<ActionResult<QueryResult<DeviceControlTask>>> QueryDeviceControlTasksAsync([FromRoute] long deviceId)
        {
            return await deviceQuery.GetDeviceControlTasksAsync(deviceId);
        }

        /// <summary>
        /// 异步获取设备控制任务
        /// </summary>
        /// <param name="deviceId">设备 Id</param>
        /// <param name="taskId">设备控制任务 Id</param>
        /// <returns></returns>
        [HttpGet("{deviceId:long}/device-control-tasks/{taskId:long}")]
        public async Task<ActionResult<DeviceControlTask>> GetDeviceControlTaskAsync([FromRoute] long deviceId, [FromRoute] long taskId)
        {
            return await deviceQuery.GetDeviceControlTaskAsync(deviceId, taskId);
        }
    }
}