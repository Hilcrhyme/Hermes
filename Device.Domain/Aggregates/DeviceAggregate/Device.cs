﻿using Hermes.Common.SeedWork;
using Hermes.Service.Device.Domain.Aggregates.ControlPlanAggregate;
using Hermes.Service.Device.Domain.Aggregates.UpdatePlanAggregate;

namespace Hermes.Service.Device.Domain.Aggregates.DeviceAggregate
{
    /// <summary>
    /// 设备  
    /// </summary>
    public abstract class Device : Entity, IAggregateRoot
    {
        /// <summary>
        /// 设备代码
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 设备名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 设备类型
        /// </summary>
        public DeviceType Type { get; set; } = DeviceType.Unknown;

        /// <summary>
        /// 设备状态
        /// </summary>
        public DeviceState State { get; set; } = DeviceState.Unknown;

        /// <summary>
        /// 环境 Id
        /// </summary>
        public long EnvironmentId { get; set; } = 0;

        /// <summary>
        /// 业务 Id
        /// </summary>
        public long BusinessId { get; set; } = 0;

        /// <summary>
        /// 供应商 Id
        /// </summary>
        public long SupplierId { get; set; } = 0;

        /// <summary>
        /// 批次 Id
        /// </summary>
        public long BatchId { get; set; } = 0;

        /// <summary>
        /// 客户 Id
        /// </summary>
        public long CustomerId { get; set; } = 0;

        /// <summary>
        /// 工厂 Id
        /// </summary>
        public long FactoryId { get; set; } = 0;

        /// <summary>
        /// 区域 Id
        /// </summary>
        public long AreaId { get; set; } = 0;

        /// <summary>
        /// 小组 Id
        /// </summary>
        public long GroupId { get; set; } = 0;

        /// <summary>
        /// 位置
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// 软件枚举
        /// </summary>
        public virtual IEnumerable<Software> Softwares { get; set; } = Enumerable.Empty<Software>();

        /// <summary>
        /// 硬件版本
        /// </summary>
        public string HardwareVersion { get; set; } = string.Empty;

        /// <summary>
        /// 数据字典
        /// </summary>
        public virtual IDictionary<string, string> DataDictionary { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 连接枚举
        /// </summary>
        public virtual IEnumerable<Connection> Connections { get; set; } = Enumerable.Empty<Connection>();

        /// <summary>
        /// 设备日志枚举
        /// </summary>
        public virtual IEnumerable<DeviceLog> Logs { get; set; } = Enumerable.Empty<DeviceLog>();

        /// <summary>
        /// 更新任务枚举
        /// </summary>
        public IEnumerable<UpdateTask> UpdateTasks { get; set; } = Enumerable.Empty<UpdateTask>();

        /// <summary>
        /// 设备任务集合
        /// </summary>
        public virtual IEnumerable<ControlTask> ControlTasks { get; set; } = Enumerable.Empty<ControlTask>();

        /// <summary>
        /// 设备是否已连接至平台
        /// </summary>
        public bool IsConnected => Connections.Where(connection => connection.IsConnected).Any();

        /// <summary>
        /// 设备是否已激活
        /// </summary>
        public bool IsActivated { get; set; } = false;

        /// <summary>
        /// 设备是否已锁定
        /// </summary>
        public bool IsLocked { get; set; } = false;
    }
}