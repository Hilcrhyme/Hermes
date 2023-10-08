using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.Command;
using Hermes.Service.Device.Domain.Aggregate.UpdatePlanAggregate;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 更新计划查询接口
    /// </summary>
    public interface IUpdatePlanQuery
    {
        /// <summary>
        /// 异步获取更新子任务
        /// </summary>
        /// <param name="subUpdateTaskId">更新子任务 Id</param>
        /// <returns></returns>
        Task<UpdateTask?> GetSubUpdateTaskAsync(long subUpdateTaskId);

        /// <summary>
        /// 异步查询更新任务
        /// </summary>
        /// <param name="updateTaskQueryCommand">更新任务查询命令</param>
        /// <returns></returns>
        Task<QueryResult<DataTransferObject.UpdateTask>> QueryUpdateTasksAsync(UpdateTaskQueryCommand updateTaskQueryCommand);

        /// <summary>
        /// 异步获取更新任务
        /// </summary>
        /// <param name="updateTaskId">更新任务 Id</param>
        /// <returns></returns>
        Task<DataTransferObject.UpdateTask?> GetUpdateTaskAsync(long updateTaskId);
    }
}