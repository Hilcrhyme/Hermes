using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.DeviceAggregate
{
    /// <summary>
    /// 设备控制任务
    /// </summary>
    public class DeviceControlTask : Entity
    {
        /// <summary>
        /// 任务状态
        /// </summary>
        public DeviceControlTaskState State { get; internal set; } = DeviceControlTaskState.Unknown;

        /// <summary>
        /// 任务超时
        /// </summary>
        public int Timeout { get; set; } = 0;

        /// <summary>
        /// 任务数据
        /// </summary>
        public string Data { get; set; } = string.Empty;

        /// <summary>
        /// 任务结果
        /// </summary>
        public bool? Result { get; set; } = null;

        /// <summary>
        /// 任务消息
        /// </summary>
        public string? Message { get; set; } = null;

        /// <summary>
        /// 任务响应
        /// </summary>
        public string? Response { get; set; } = null;
    }
}