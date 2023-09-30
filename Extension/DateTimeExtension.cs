namespace Hermes.Common.Extension
{
    /// <summary>
    /// <see cref="DateTime"/> 扩展方法
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 转换为自 1970-01-01T00:00:00.000Z 以来经过的秒数
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static long ToUnixTimeSeconds(this DateTime dateTime)
        {
            var offset = new DateTimeOffset(dateTime);
            return offset.ToUnixTimeSeconds();
        }

        /// <summary>
        /// 转换为自 1970-01-01T00:00:00.000Z 以来经过的毫秒数
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static long ToUnixTimeMilliseconds(this DateTime dateTime)
        {
            var offset = new DateTimeOffset(dateTime);
            return offset.ToUnixTimeMilliseconds();
        }
    }
}