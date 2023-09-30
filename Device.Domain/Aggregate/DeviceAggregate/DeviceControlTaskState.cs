namespace Hermes.Service.Device.Domain.Aggregate.DeviceAggregate
{
    /// <summary>
    /// 设备控制任务状态
    /// </summary>
    public enum DeviceControlTaskState
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 设备控制任务创建失败
        /// </summary>
        CreationFailed = 1,

        /// <summary>
        /// 设备控制任务推送中
        /// </summary>
        Pushing = 2,

        /// <summary>
        /// 设备控制任务投递超时
        /// </summary>
        DeliveryTimeout = 3,

        /// <summary>
        /// 设备控制任务执行中
        /// </summary>
        Executing = 4,

        /// <summary>
        /// 设备控制任务执行超时
        /// </summary>
        ExecutionTimeout = 5,

        /// <summary>
        /// 设备控制任务完成
        /// </summary>
        Done = 6
    }
}