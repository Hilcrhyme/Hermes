namespace Hermes.Service.Device.Domain.Aggregates.MqttEventAggregate
{
    /// <summary>
    /// 服务质量
    /// </summary>
    public enum QualityofService
    {
        /// <summary>
        /// 至多一次
        /// </summary>
        AtMostOnce = 0,

        /// <summary>
        /// 至少一次
        /// </summary>
        AtLeastOnce = 1,

        /// <summary>
        /// 正好一次
        /// </summary>
        ExactlyOnce = 2
    }
}