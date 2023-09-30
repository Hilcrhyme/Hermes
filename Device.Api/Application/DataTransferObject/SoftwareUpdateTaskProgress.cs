namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 软件更新任务进度
    /// </summary>
    public readonly record struct SoftwareUpdateTaskProgress
    {
        /// <summary>
        /// 软件更新任务 Id
        /// </summary>
        public long SoftwareUpdateTaskId { get; init; }

        /// <summary>
        /// 进度值
        /// </summary>
        public int Value { get; init; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; init; }

        /// <summary>
        /// 同步的时间
        /// </summary>
        public DateTime SynchronizedTime { get; init; }
    }
}