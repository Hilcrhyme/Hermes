using AutoMapper;
using System.Linq.Expressions;

using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.Command;
using Hermes.Service.Device.Domain.Aggregate.UpdatePlanAggregate;
using Hermes.Common.Extension;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 更新计划查询
    /// </summary>
    public class UpdatePlanQuery : IUpdatePlanQuery
    {
        public Task<UpdateTask?> GetSubUpdateTaskAsync(long subUpdateTaskId)
        {
            throw new NotImplementedException();
        }

        public Task<DataTransferObject.UpdateTask?> GetUpdateTaskAsync(long updateTaskId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 异步查询更新任务
        /// </summary>
        /// <param name="updateTaskQueryCommand">更新任务查询命令</param>
        /// <returns></returns>
        public Task<QueryResult<DataTransferObject.UpdateTask>> QueryUpdateTasksAsync(UpdateTaskQueryCommand updateTaskQueryCommand)
        {
            Expression<Func<UpdateTask, bool>> filterExpression = p => true;
            if (updateTaskQueryCommand.DeviceId is not null)
            {
                filterExpression = filterExpression.And(softwareUpdateTask => softwareUpdateTask.DeviceId == updateTaskQueryCommand.DeviceId);
            }
            if (updateTaskQueryCommand.UpdatePlanId is not null)
            {
                filterExpression = filterExpression.And(softwareUpdateTask => softwareUpdateTask.Id == updateTaskQueryCommand.UpdatePlanId);
            }
            var queryOptions = new QueryOptions<UpdateTask>()
            {
                Filter = filterExpression
            };
            var result = await deviceRepository.que(deviceId, queryOptions);
            return new QueryResult<DataTransferObject.DeviceLog>()
            {
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                Items = result.Items.Select(mapper.Map<DataTransferObject.UpdateTask>)
            };
        }
    }
}