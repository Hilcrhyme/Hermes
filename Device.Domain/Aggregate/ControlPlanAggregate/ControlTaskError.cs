namespace Hermes.Service.Device.Domain.Aggregate.ControlPlanAggregate
{
    /// <summary>
    /// 控制任务错误
    /// </summary>
    public enum ControlTaskError
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 设备不存在
        /// </summary>
        DeviceNotFound = 1,

        /// <summary>
        /// 设备未激活
        /// </summary>
        DeviceNotActivated = 2,

        /// <summary>
        /// 设备已锁定
        /// </summary>
        DeviceLocked = 3,

        /// <summary>
        /// 设备访问被拒绝
        /// </summary>
        DeviceAccessDenied = 4,

        /// <summary>
        /// 推送超时
        /// </summary>
        PushTimeout = 5,

        /// <summary>
        /// 执行超时
        /// </summary>
        ExecutionTimeout = 6
    }
}