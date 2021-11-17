using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using Vue3_Vite.Entities;
using Vue3_Vite.Helper;

namespace Vue3_Vite.Filter
{
    /// <summary>
    /// Api action统一处理过滤器
    /// 处理正常返回值 {code:200,body:{}}
    /// </summary>
    public class ApiResponseFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //模型验证
            if (!context.ModelState.IsValid)
            {
                throw new ApplicationException(context.ModelState.Values.First(p => p.Errors.Count > 0).Errors[0].ErrorMessage);
            }
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// 处理正常返回的结果对象，进行统一json格式包装
        /// 异常只能交由ExceptionFilterAttribute 去处理
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result != null)
            {
                ResultInfo newResult;
                if (context.Result is not EmptyResult)
                {
                    if (context.Result is ObjectResult result)
                    {
                        newResult = ResultHelper.Success(data: result.Value);
                    }
                    else
                    {
                        newResult = ResultHelper.Success(data: context.Result);
                    }
                }
                else
                {
                    newResult = ResultHelper.Success(data: string.Empty);
                }
                context.Result = new JsonResult(newResult);
            }
            base.OnActionExecuted(context);
        }
    }
}