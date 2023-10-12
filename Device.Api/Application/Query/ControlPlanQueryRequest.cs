namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 控制计划查询请求
    /// </summary>
    public record class ControlPlanQueryRequest : QueryRequest
    {
        /// <summary>
        /// 控制计划 Id
        /// </summary>
        public long? ControlPlanId { get; init; } = null;

        /// <summary>
        /// 控制计划名称
        /// </summary>
        public string? ControlPlanName { get; init; } = null;
    }
}