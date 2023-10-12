using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregates.UpdatePlanAggregate
{
    /// <summary>
    /// 更新任务
    /// </summary>
    public class UpdateTask : Entity
    {
        /// <summary>
        /// 执行更新任务的设备 Id
        /// </summary>
        public long DeviceId { get; private init; } = 0;

        /// <summary>
        /// 更新任务所属更新计划 Id
        /// </summary>
        public long UpdatePlanId { get; private init; } = 0;

        /// <summary>
        /// 更新包 Id
        /// </summary>
        public long UpdatePackageId { get; private init; } = 0;

        /// <summary>
        /// 更新任务状态
        /// </summary>
        public UpdateTaskState State { get; private set; } = UpdateTaskState.Unknown;

        /// <summary>
        /// 更新任务进度枚举
        /// </summary>
        public IEnumerable<UpdateTaskProgress> Progresses { get; private set; } = Enumerable.Empty<UpdateTaskProgress>();

        /// <summary>
        /// 实例化更新任务
        /// </summary>
        /// <param name="id">更新任务 Id</param>
        /// <param name="deviceId">执行更新任务的设备 Id</param>
        /// <param name="updatePlanId">更新任务所属更新计划 Id</param>
        /// <param name="updatePackageId">更新包 Id</param>
        public UpdateTask(long id, long deviceId, long updatePlanId, long updatePackageId)
        {
            Id = id; 
            DeviceId = deviceId; 
            UpdatePlanId = updatePlanId; 
            UpdatePackageId = updatePackageId;
        }

        /// <summary>
        /// 取消更新任务
        /// </summary>
        public void Cancel()
        {
            State = UpdateTaskState.Cancelled;
        }
    }
}