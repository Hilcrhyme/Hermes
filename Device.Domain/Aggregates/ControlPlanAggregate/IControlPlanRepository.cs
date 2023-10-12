using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregates.ControlPlanAggregate
{
    /// <summary>
    /// 控制计划仓储接口
    /// </summary>
    public interface IControlPlanRepository : IRepository<ControlPlan>
    {
    }
}