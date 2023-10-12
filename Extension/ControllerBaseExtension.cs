using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Common.Extension
{
    /// <summary>
    /// <seealso cref="ControllerBase"/> 扩展方法
    /// </summary>
    public static class ControllerBaseExtension
    {
        /// <summary>
        /// 发生內部服务器错误
        /// </summary>
        /// <param name="controllerBase">控制器</param>
        /// <returns></returns>
        public static ActionResult InternalServerError(this ControllerBase controllerBase)
        {
            return controllerBase.StatusCode(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// 发生內部服务器错误
        /// </summary>
        /// <param name="controllerBase">控制器</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static ActionResult InternalServerError(this ControllerBase controllerBase, object value)
        {
            return controllerBase.StatusCode(StatusCodes.Status500InternalServerError, value);
        }
    }
}