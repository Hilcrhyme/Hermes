using Hermes.Service.Device.Domain.Aggregate.UpdateTaskAggregate;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 更新子任务查询
    /// </summary>
    public class UpdateTaskQuery : IUpdateTaskQuery
    {
        public Task<SubUpdateTask?> GetSubUpdateTaskAsync(long subUpdateTaskId)
        {
            throw new NotImplementedException();
        }
    }
}