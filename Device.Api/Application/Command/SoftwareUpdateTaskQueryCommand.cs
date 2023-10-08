namespace Hermes.Service.Device.Api.Application.Command
{
    /// <summary>
    /// 软件更新任务查询命令
    /// </summary>
    public record class SoftwareUpdateTaskQueryCommand : QueryCommand
    {
        /// <summary>
        /// 软件更新任务 Id
        /// </summary>
        public long? SoftwareUpdateTaskId { get; init; } = 0;

        /// <summary>
        /// 软件更新任务名称
        /// </summary>
        public string? SoftwareUpdateTaskName { get; init; } = string.Empty;
    }
}