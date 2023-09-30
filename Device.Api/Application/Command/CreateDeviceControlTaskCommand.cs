using Hermes.Service.Device.Api.Application.DataTransferObject;

using MediatR;

namespace Hermes.Service.Device.Api.Application.Command
{
    /// <summary>
    /// 创建设备控制任务命令
    /// </summary>
    public class CreateDeviceControlTaskCommand : IRequest<Response>
    {
        /// <summary>
        /// 设备 Id 枚举
        /// </summary>
        public IEnumerable<long> Devices { get; init; } = Enumerable.Empty<long>();

        /// <summary>
        /// 任务数据
        /// </summary>
        public string TaskData { get; init; } = string.Empty;

        /// <summary>
        /// 任务超时
        /// <para>业务方对控制任务的超时时间，包括平台对控制任务的投递和设备对控制任务的执行</para>
        /// <para>单位为秒，默认为 3600</para>
        /// </summary>
        public int TaskTimeout { get; init; } = 3600;
    }
}