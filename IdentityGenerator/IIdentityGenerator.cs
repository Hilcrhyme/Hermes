namespace Hermes.Common.IdentityGenerator
{
    /// <summary>
    /// Id 生成器接口
    /// </summary>
    /// <typeparam name="T">Id 的数据类型</typeparam>
    public interface IIdentityGenerator<T>
    {
        /// <summary>
        /// 异步获取下一个 Id
        /// </summary>
        /// <returns></returns>
        ValueTask<T> GetNextIdAsync();
    }
}