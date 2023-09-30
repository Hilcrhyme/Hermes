using Hermes.Service.Device.Domain.Aggregate.DeviceAggregate;

namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 设备
    /// </summary>
    public readonly record struct Device
    {
        /// <summary>
        /// 设备 Id
        /// </summary>
        public long Id { get; init; }

        /// <summary>
        /// 设备代码
        /// </summary>
        public string Code { get; init; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public DeviceType Type { get; init; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public DeviceState State { get; init; }

        /// <summary>
        /// 环境 Id
        /// </summary>
        public long EnvironmentId { get; init; }

        /// <summary>
        /// 业务 Id
        /// </summary>
        public long BusinessId { get; init; }

        /// <summary>
        /// 供应商 Id
        /// </summary>
        public long SupplierId { get; init; }

        /// <summary>
        /// 批次 Id
        /// </summary>
        public long BatchId { get; init; }

        /// <summary>
        /// 客户 Id
        /// </summary>
        public long CustomerId { get; init; }

        /// <summary>
        /// 工厂 Id
        /// </summary>
        public long FactoryId { get; init; }

        /// <summary>
        /// 区域 Id
        /// </summary>
        public long AreaId { get; init; }

        /// <summary>
        /// 小组 Id
        /// </summary>
        public long GroupId { get; init; }

        /// <summary>
        /// 位置
        /// </summary>
        public string Location { get; init; }

        /// <summary>
        /// 软件枚举
        /// </summary>
        public IEnumerable<Software> Softwares { get; init; }

        /// <summary>
        /// 硬件版本
        /// </summary>
        public string HardwareVersion { get; init; }

        /// <summary>
        /// 数据键值对枚举
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> KeyValuePairs { get; init; }

        /// <summary>
        /// 连接枚举
        /// </summary>
        public IEnumerable<Connection> Connections { get; init; }

        /// <summary>
        /// 设备是否已连接至平台
        /// </summary>
        public bool IsConnected => Connections.Where(connection => connection.IsConnected).Any();

        /// <summary>
        /// 设备是否已激活
        /// </summary>
        public bool IsActivated { get; init; }

        /// <summary>
        /// 设备是否已锁定
        /// </summary>
        public bool IsLocked { get; init; }
    }
}