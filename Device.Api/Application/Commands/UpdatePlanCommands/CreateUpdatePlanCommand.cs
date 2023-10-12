using MediatR;

namespace Hermes.Service.Device.Api.Application.Commands.UpdatePlanCommands
{
    /// <summary>
    /// 创建更新计划命令
    /// </summary>
    public readonly record struct CreateUpdatePlanCommand : IRequest<long>
    {
        /// <summary>
        /// 更新计划名称
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// 更新包 Id
        /// </summary>
        public long UpdatePackageId { get; init; }

        /// <summary>
        /// 进行更新的设备枚举
        /// </summary>
        public IEnumerable<long> Devices { get; init; }
    }
}