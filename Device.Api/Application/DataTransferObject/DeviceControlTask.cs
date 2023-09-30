namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 设备控制任务
    /// </summary>
    public readonly record struct DeviceControlTask
    {
        /// <summary>
        /// 任务数据
        /// </summary>
        public string Data { get; init; }

        /// <summary>
        /// 任务超时
        /// <para>业务方对控制任务的超时时间，包括平台对控制任务的投递和设备对控制任务的执行</para>
        /// <para>单位为秒，默认为 3600</para>
        /// </summary>
        public int Timeout { get; init; }
    }
}