using Hermes.Service.Device.Domain.Aggregate.DeviceAggregate;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 设备查询条件
    /// </summary>
    public record class DeviceQueryCondition : QueryCondition
    {
        /// <summary>
        /// 设备 Id
        /// </summary>
        public long? Id { get; init; } = 0;

        /// <summary>
        /// 设备代码
        /// </summary>
        public string? Code { get; init; } = null;

        /// <summary>
        /// 设备名称
        /// </summary>
        public string? Name { get; init; } = null;

        /// <summary>
        /// 设备类型
        /// </summary>
        public DeviceType? Type { get; init; } = null;

        /// <summary>
        /// 设备状态
        /// </summary>
        public DeviceState? State { get; init; } = null;

        /// <summary>
        /// 环境 Id
        /// </summary>
        public long? EnvironmentId { get; init; } = null;

        /// <summary>
        /// 业务 Id
        /// </summary>
        public long? BusinessId { get; init; } = null;

        /// <summary>
        /// 供应商 Id
        /// </summary>
        public long? SupplierId { get; init; } = null;

        /// <summary>
        /// 批次 Id
        /// </summary>
        public long? BatchId { get; init; } = null;

        /// <summary>
        /// 客户 Id
        /// </summary>
        public long? CustomerId { get; init; } = null;

        /// <summary>
        /// 工厂 Id
        /// </summary>
        public long? FactoryId { get; init; } = null;

        /// <summary>
        /// 区域 Id
        /// </summary>
        public long? AreaId { get; init; } = null;

        /// <summary>
        /// 小组 Id
        /// </summary>
        public long? GroupId { get; init; } = null;

        /// <summary>
        /// 位置
        /// </summary>
        public string? Location { get; init; } = null;

        /// <summary>
        /// 硬件版本
        /// </summary>
        public string? HardwareVersion { get; init; } = null;

        /// <summary>
        /// 设备是否已连接至平台
        /// </summary>
        public bool? IsConnected { get; init; } = null;

        /// <summary>
        /// 设备是否已激活
        /// </summary>
        public bool? IsActivated { get; init; } = null;

        /// <summary>
        /// 设备是否已锁定
        /// </summary>
        public bool? IsLocked { get; init; } = null;
    }
}