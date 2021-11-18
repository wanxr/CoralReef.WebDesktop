using System.Text.Json.Serialization;
using Vue3_Vite.Entities;

namespace Vue3_Vite.Helper
{
    public class ResultHelper
    {
        public static ResultInfo Success(object data, string message = "")
        {
            return new ResultInfo
            {
                Code = ResultStatusCode.Success,
                Data = data,
                Message = message,
                IsSuccess = true
            };
        }

        public static ResultInfo Error(object data, string message, ResultStatusCode code = ResultStatusCode.Error)
        {
            return new ResultInfo
            {
                Code = code,
                Data = data,
                Message = message,
                IsSuccess = false
            };
        }
    }
}