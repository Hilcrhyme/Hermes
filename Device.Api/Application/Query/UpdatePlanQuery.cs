using AutoMapper;
using System.Linq.Expressions;

using Hermes.Common.SeedWork;
using Hermes.Service.Device.Domain.Aggregate.UpdatePlanAggregate;
using Hermes.Common.Extension;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 更新计划查询
    /// </summary>
    public class UpdatePlanQuery : IUpdatePlanQuery
    {
        /// <summary>
        /// 更新计划仓储
        /// </summary>
        private readonly IUpdatePlanRepository updatePlanRepository;

        /// <summary>
        /// 映射器
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// 实例化更新计划查询
        /// </summary>
        /// <param name="updatePlanRepository">更新计划仓储</param>
        /// <param name="mapper">映射器</param>
        public UpdatePlanQuery(IUpdatePlanRepository updatePlanRepository, IMapper mapper)
        {
            this.updatePlanRepository = updatePlanRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// 异步获取更新计划
        /// </summary>
        /// <param name="updatePlanId">更新计划 Id</param>
        /// <returns></returns>
        public async Task<DataTransferObject.UpdatePlan?> GetUpdatePlanAsync(long updatePlanId)
        {
            var plan = await updatePlanRepository.GetUpdatePlanAsync(updatePlanId);
            return mapper.Map<DataTransferObject.UpdatePlan>(plan);
        }

        /// <summary>
        /// 异步查询更新计划
        /// </summary>
        /// <param name="updatePlanQueryRequest">更新计划查询请求</param>
        /// <returns></returns>
        public async Task<QueryResult<DataTransferObject.UpdatePlan>> QueryUpdatePlansAsync(UpdatePlanQueryRequest updatePlanQueryRequest)
        {
            Expression<Func<UpdatePlan, bool>> filterExpression = p => true;
            if (updatePlanQueryRequest.UpdatePlanId is not null)
            {
                filterExpression = filterExpression.And(updatePlan => updatePlan.Id == updatePlanQueryRequest.UpdatePlanId);
            }
            if (updatePlanQueryRequest.UpdatePlanName is not null)
            {
                filterExpression = filterExpression.And(updatePlan => updatePlan.Name == updatePlanQueryRequest.UpdatePlanName);
            }
            if (updatePlanQueryRequest.UpdatePlanName is not null)
            {
                filterExpression = filterExpression.And(updatePlan => updatePlan.Name == updatePlanQueryRequest.UpdatePlanName);
            }
            var queryOptions = new QueryOptions<UpdatePlan>()
            {
                Filter = filterExpression
            };
            var result = await updatePlanRepository.QueryUpdatePlanAsync(queryOptions);
            return new QueryResult<DataTransferObject.UpdatePlan>()
            {
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                Items = result.Items.Select(mapper.Map<DataTransferObject.UpdatePlan>)
            };
        }

        /// <summary>
        /// 异步获取更新任务
        /// </summary>
        /// <param name="updateTaskId">更新任务 Id</param>
        /// <returns></returns>
        public async Task<DataTransferObject.UpdateTask?> GetUpdateTaskAsync(long updateTaskId)
        {
            var updateTask = await updatePlanRepository.GetUpdateTaskAsync(updateTaskId);
            return mapper.Map<DataTransferObject.UpdateTask>(updateTask);
        }

        /// <summary>
        /// 异步查询更新任务
        /// </summary>
        /// <param name="updateTaskQueryRequest">更新任务查询请求</param>
        /// <returns></returns>
        public async Task<QueryResult<DataTransferObject.UpdateTask>> QueryUpdateTasksAsync(UpdateTaskQueryRequest updateTaskQueryRequest)
        {
            Expression<Func<UpdateTask, bool>> filterExpression = p => true;
            if (updateTaskQueryRequest.DeviceId is not null)
            {
                filterExpression = filterExpression.And(updateTask => updateTask.DeviceId == updateTaskQueryRequest.DeviceId);
            }
            if (updateTaskQueryRequest.UpdatePlanId is not null)
            {
                filterExpression = filterExpression.And(updateTask => updateTask.Id == updateTaskQueryRequest.UpdatePlanId);
            }
            var queryOptions = new QueryOptions<UpdateTask>()
            {
                Filter = filterExpression
            };
            var result = await updatePlanRepository.QueryUpdateTaskAsync(queryOptions);
            return new QueryResult<DataTransferObject.UpdateTask>()
            {
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                Items = result.Items.Select(mapper.Map<DataTransferObject.UpdateTask>)
            };
        }
    }
}