using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Vue3_Vite.Helper;

namespace Vue3_Vite.Filters
{
    /// <summary>
    /// api异常统一处理过滤器
    /// 系统级别异常 500 应用级别异常501
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                context.Result = BuildExceptionResult(context.Exception);
                context.ExceptionHandled = true;
            }
            //base.OnException(context);
        }

        /// <summary>
        /// 包装处理异常格式
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private JsonResult BuildExceptionResult(Exception ex)
        {
            string message = ex.Message;

            if (ex.InnerException != null && ex.Message != ex.InnerException.Message)
            {
                message = $@"{message}\n{ex.InnerException.Message}";
            }

            JsonResult jsonResult = new JsonResult(ResultHelper.Error(string.Empty, message));
            return jsonResult;
        }
    }
}