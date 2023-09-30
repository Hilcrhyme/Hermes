namespace Hermes.Common.IdentityGenerator.Exception
{
    /// <summary>
    /// 时间倒流异常
    /// </summary>
    public class TimeRewindException : System.Exception
    {
        /// <summary>
        /// 异常消息
        /// </summary>
        public override string Message => "There is a time rewind.";
    }
}