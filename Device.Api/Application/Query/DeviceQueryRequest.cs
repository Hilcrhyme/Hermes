using Hermes.Service.Device.Domain.Aggregate.DeviceAggregate;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 设备查询请求
    /// </summary>
    public record class DeviceQueryRequest : QueryRequest
    {
        /// <summary>
        /// 设备 Id
        /// </summary>
        public long? Id { get; init; } = 0;

        /// <summary>
        /// 设备代码
        /// </summary>
        public string? Code { get; init; } = string.Empty;

        /// <summary>
        /// 设备名称
        /// </summary>
        public string? Name { get; init; } = string.Empty;

        /// <summary>
        /// 设备类型
        /// </summary>
        public DeviceType? Type { get; init; } = DeviceType.Unknown;

        /// <summary>
        /// 设备状态
        /// </summary>
        public DeviceState? State { get; init; } = DeviceState.Unknown;

        /// <summary>
        /// 环境 Id
        /// </summary>
        public long? EnvironmentId { get; init; } = 0;

        /// <summary>
        /// 业务 Id
        /// </summary>
        public long? BusinessId { get; init; } = 0;

        /// <summary>
        /// 供应商 Id
        /// </summary>
        public long? SupplierId { get; init; } = 0;

        /// <summary>
        /// 批次 Id
        /// </summary>
        public long? BatchId { get; init; } = 0;

        /// <summary>
        /// 客户 Id
        /// </summary>
        public long? CustomerId { get; init; } = 0;

        /// <summary>
        /// 工厂 Id
        /// </summary>
        public long? FactoryId { get; init; } = 0;

        /// <summary>
        /// 区域 Id
        /// </summary>
        public long? AreaId { get; init; } = 0;

        /// <summary>
        /// 分组 Id
        /// </summary>
        public long? GroupId { get; init; } = 0;

        /// <summary>
        /// 位置
        /// </summary>
        public string? Location { get; init; } = string.Empty;

        /// <summary>
        /// 硬件版本
        /// </summary>
        public string? HardwareVersion { get; init; } = string.Empty;

        /// <summary>
        /// 设备是否已连接至平台
        /// </summary>
        public bool? IsConnected { get; init; } = false;

        /// <summary>
        /// 设备是否已激活
        /// </summary>
        public bool? IsActivated { get; init; } = false;

        /// <summary>
        /// 设备是否已锁定
        /// </summary>
        public bool? IsLocked { get; init; } = false;
    }
}