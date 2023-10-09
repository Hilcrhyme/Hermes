namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 更新进度
    /// </summary>
    public readonly record struct UpdateProgress
    {
        /// <summary>
        /// 更新任务 Id
        /// </summary>
        public long UpdateTaskId { get; init; }

        /// <summary>
        /// 进度值
        /// </summary>
        public int Value { get; init; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; init; }

        /// <summary>
        /// 同步时间
        /// </summary>
        public DateTime SynchronizedTime { get; init; }
    }
}