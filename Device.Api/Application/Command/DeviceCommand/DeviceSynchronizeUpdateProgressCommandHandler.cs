using Hermes.Service.Device.Api.Application.Query;
using Hermes.Service.Device.Domain.Aggregate.UpdatePlanAggregate;

namespace Hermes.Service.Device.Api.Application.Command.DeviceCommand
{
    /// <summary>
    /// 设备同步更新进度命令处理器
    /// </summary>
    public class DeviceSynchronizeUpdateProgressCommandHandler : CommunicationCommandHandler<DeviceSynchronizeUpdateProgressCommand>
    {
        /// <summary>
        /// 设备查询
        /// </summary>
        private readonly IDeviceQuery deviceQuery;

        /// <summary>
        /// 更新计划仓储
        /// </summary>
        private readonly IUpdatePlanRepository updatePlanRepository;

        /// <summary>
        /// 日志器
        /// </summary>
        private readonly ILogger<DeviceSynchronizeUpdateProgressCommandHandler> logger;

        /// <summary>
        /// 实例化设备同步更新进度命令处理器
        /// </summary>
        /// <param name="deviceQuery">设备查询</param>
        /// <param name="updatePlanRepository">更新计划仓储</param>
        /// <param name="logger">日志器</param>
        public DeviceSynchronizeUpdateProgressCommandHandler(IDeviceQuery deviceQuery, IUpdatePlanRepository updatePlanRepository, ILogger<DeviceSynchronizeUpdateProgressCommandHandler> logger)
        {
            this.deviceQuery = deviceQuery;
            this.updatePlanRepository = updatePlanRepository;
            this.logger = logger;
        }

        /// <summary>
        /// 异步处理设备同步更新子任务进度命令
        /// </summary>
        /// <param name="request">设备同步更新子任务进度命令</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public override async Task Handle(DeviceSynchronizeUpdateProgressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await updatePlanRepository.SynchronizeUpdateProgressAsync(request.Data.UpdateTaskId, request.Data.Value, request.Data.Message, DateTimeOffset.FromUnixTimeMilliseconds(request.Timestamp).DateTime);
            }
            catch (Exception)
            {
                logger.LogCritical();
            }
        }
    }
}