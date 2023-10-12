using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands
{
    /// <summary>
    /// 创建控制计划命令
    /// </summary>
    public readonly record struct CreateControlPlanCommand : IRequest<long>
    {
        /// <summary>
        /// 控制计划名称
        /// </summary>
        public string ControlPlanName { get; init; }

        /// <summary>
        /// 控制计划数据
        /// </summary>
        public string ControlPlanData { get; init; }

        /// <summary>
        /// 控制计划超时
        /// </summary>
        public TimeSpan ControlPlanTimeout { get; init; }

        /// <summary>
        /// 执行控制计划的设备枚举
        /// </summary>
        public IEnumerable<long> Devices { get; init; }
    }
}