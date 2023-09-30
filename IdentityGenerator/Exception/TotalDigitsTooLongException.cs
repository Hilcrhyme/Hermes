namespace Hermes.Common.IdentityGenerator.Exception
{
    /// <summary>
    /// 总位数过长异常
    /// </summary>
    public class TotalDigitsTooLongException : System.Exception
    {
        /// <summary>
        /// 异常消息
        /// </summary>
        public override string Message => "The total digits are too long.";
    }
}