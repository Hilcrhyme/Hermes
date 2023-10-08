using Hermes.Service.Device.Api.Application.Query;
using Hermes.Service.Device.Domain.Aggregate.DeviceAggregate;
using Hermes.Service.Device.Domain.Aggregate.UpdatePlanAggregate;

namespace Hermes.Service.Device.Api.Application.Command.DeviceCommand
{
    /// <summary>
    /// 设备同步更新子任务进度命令处理器
    /// </summary>
    public class DeviceSynchronizeSubUpdateTaskProgressCommandHandler : CommunicationCommandHandler<DeviceSynchronizeSubUpdateTaskProgressCommand>
    {
        /// <summary>
        /// 设备查询
        /// </summary>
        private readonly IDeviceQuery deviceQuery;

        /// <summary>
        /// 更新任务领域服务
        /// </summary>
        private readonly IUpdateTaskDomainService updateTaskDomainService;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<DeviceSynchronizeSubUpdateTaskProgressCommandHandler> logger;

        /// <summary>
        /// 实例化设备同步更新子任务进度命令处理器
        /// </summary>
        /// <param name="deviceQuery">设备查询</param>
        /// <param name="updateTaskDomainService">更新任务领域服务</param>
        /// <param name="logger">日志器</param>
        public DeviceSynchronizeSubUpdateTaskProgressCommandHandler(IDeviceQuery deviceQuery, IUpdateTaskDomainService updateTaskDomainService, ILogger<DeviceSynchronizeSubUpdateTaskProgressCommandHandler> logger)
        {
            this.deviceQuery = deviceQuery;
            this.updateTaskDomainService = updateTaskDomainService;
            this.logger = logger;
        }

        /// <summary>
        /// 异步处理设备同步更新子任务进度命令
        /// </summary>
        /// <param name="request">设备同步更新子任务进度命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public override async Task Handle(DeviceSynchronizeSubUpdateTaskProgressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await updateTaskDomainService.SynchronizeUpdateProgressAsync(request.Data.SubUpdateTaskId, request.Data.Value, request.Data.Message, DateTimeOffset.FromUnixTimeMilliseconds(request.Timestamp).DateTime);
            }
            catch (Exception ex)
            {
                logger.LogCritical();
            }
        }
    }
}