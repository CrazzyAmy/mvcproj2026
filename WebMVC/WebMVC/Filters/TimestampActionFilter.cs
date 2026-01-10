using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMVC.Filters
{
    /// <summary>
    /// 記錄 Action 執行時間的過濾器，通常用於除錯或效能分析
    /// </summary>
    public class TimestampActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Action 執行前記錄開始時間
            var startTime = DateTime.Now;
            context.HttpContext.Items["ActionStartTime"] = startTime;
            Console.WriteLine($"TimestampActionFilter - Before Action Execution：{DateTime.Now}");

            //await next();
            var resultContext = await next();

            // Action 執行後記錄開始時間
            var endTime = DateTime.Now;
            context.HttpContext.Items["ActionEndTime"] = endTime;
            Console.WriteLine($"TimestampActionFilter - After Action Execution：{DateTime.Now}");


            // 將時間加進 ViewData，View 才能讀到
            if (resultContext.Result is ViewResult viewResult)
            {
                viewResult.ViewData["ActionStartTime"] = startTime;
                viewResult.ViewData["ActionEndTime"] = endTime;
            }
        }
    }
}
