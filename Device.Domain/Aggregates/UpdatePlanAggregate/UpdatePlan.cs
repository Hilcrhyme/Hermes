using Hermes.Common.SeedWork;
using Hermes.Service.Device.Domain.DomainEvents;

namespace Hermes.Service.Device.Domain.Aggregates.UpdatePlanAggregate
{
    /// <summary>
    /// 更新计划
    /// </summary>
    public class UpdatePlan : Entity, IAggregateRoot
    {
        /// <summary>
        /// 更新计划名称
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// 更新计划状态
        /// </summary>
        public UpdatePlanState State { get; private set; } = UpdatePlanState.Unknown;

        /// <summary>
        /// 更新包 Id
        /// </summary>
        public long UpdatePackageId { get; private init; } = 0;

        /// <summary>
        /// 更新任务列表
        /// </summary>
        private readonly List<UpdateTask> updateTasks = new();

        /// <summary>
        /// 更新任务枚举
        /// </summary>
        public virtual IEnumerable<UpdateTask> UpdateTasks => updateTasks;

        /// <summary>
        /// 实例化更新计划
        /// </summary>
        /// <param name="id">更新计划 Id</param>
        /// <param name="name">更新计划名称</param>
        /// <param name="updatePackageId">更新包 Id</param>
        public UpdatePlan(long id, string name, long updatePackageId)
        {
            Id = id;
            Name = name;
            UpdatePackageId = updatePackageId;
        }

        /// <summary>
        /// 添加更新任务
        /// </summary>
        /// <param name="updateTaskId">更新任务 Id</param>
        /// <param name="deviceId">执行更新任务的设备 Id</param>
        public void AddUpdateTask(long updateTaskId, long deviceId)
        {
            updateTasks.Add(new UpdateTask(updateTaskId, deviceId, Id, UpdatePackageId));
        }

        /// <summary>
        /// 取消更新计划
        /// </summary>
        public void Cancel()
        {
            State = UpdatePlanState.Cancelled;
            foreach (var item in UpdateTasks)
            {
                item.Cancel();
            }
            AddDomainEvent(new UpdatePlanCancelledDomainEvent());
        }
    }
}