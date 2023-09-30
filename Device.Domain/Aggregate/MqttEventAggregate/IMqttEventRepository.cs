using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregate.MqttEventAggregate
{
    /// <summary>
    /// Mqtt 事件仓储接口
    /// </summary>
    /// <typeparam name="T">仓储元素的类型</typeparam>
    public interface IMqttEventRepository<T> : IRepository<T> where T : MqttEvent
    {
        /// <summary>
        /// 异步获取仓储元素只读集合
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<T>> GetCollectionAsync();

        /// <summary>
        /// 异步获取仓储元素只读集合
        /// </summary>
        /// <param name="count">只读集合元素总数</param>
        /// <returns></returns>
        Task<IReadOnlyCollection<T>> GetCollectionAsync(int count);

        /// <summary>
        /// 异步获取仓储元素只读集合
        /// </summary>
        /// <param name="start">查询的时间范围的起始时间</param>
        /// <param name="stop">查询的时间范围的结束时间</param>
        /// <returns></returns>
        Task<IReadOnlyCollection<T>> GetCollectionAsync(DateTime start, DateTime stop);

        /// <summary>
        /// 异步获取仓储元素只读集合
        /// </summary>
        /// <param name="start">查询的时间范围的起始时间</param>
        /// <param name="stop">查询的时间范围的结束时间</param>
        /// <param name="count">只读集合元素总数</param>
        /// <returns></returns>
        Task<IReadOnlyCollection<T>> GetCollectionAsync(DateTime start, DateTime stop, int count); 
    }
}