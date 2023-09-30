namespace Hermes.Service.Device.Api.Application.DataTransferObject
{
    /// <summary>
    /// 软件
    /// </summary>
    public readonly record struct Software
    {
        /// <summary>
        /// 软件名称
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// 软件版本
        /// </summary>
        public string Version { get; init; }
    }
}