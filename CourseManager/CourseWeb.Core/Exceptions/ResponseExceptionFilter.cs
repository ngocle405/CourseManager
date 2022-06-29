using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CourseWeb.Core.Exceptions
{
    public class ResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ResponseException http)
            {
                var result = new
                {
                    userMsg = "Dữ liệu đầu vào không hợp lệ",
                    message = http.Value
                };
                context.Result = new ObjectResult(result)
                {
                    StatusCode = 400
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception != null)
            {
                var result = new
                {
                    useMsg = "Có lỗi xảy ra",
                    message = "Có lỗi xảy ra",
                };

                context.Result = new ObjectResult(result)
                {
                    StatusCode = 500
                };
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           
        }
    }
}
