using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Vue3_Vite.Helper;

namespace Vue3_Vite.Filter
{
    /// <summary>
    /// api异常统一处理过滤器
    /// 系统级别异常 500 应用级别异常501
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = BuildExceptionResult(context.Exception);
            base.OnException(context);
        }

        /// <summary>
        /// 包装处理异常格式
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private JsonResult BuildExceptionResult(Exception ex)
        {
            int code;
            string message;
            string innerMessage = String.Empty;
            //应用程序业务级异常
            if (ex is ApplicationException)
            {
                code = 501;
                message = ex.Message;
            }
            else
            {
                // exception 系统级别异常，不直接明文显示的
                code = 500;
                message = "发生系统级别异常";
                innerMessage = ex.Message;
            }

            if (ex.InnerException != null && ex.Message != ex.InnerException.Message)
            {
                innerMessage += "," + ex.InnerException.Message;
            }

            JsonResult jsonResult = new JsonResult(ResultHelper.Error(string.Empty, $@"message:{message}, innerMessage:{innerMessage}"), code);
            return jsonResult;
        }
    }
}