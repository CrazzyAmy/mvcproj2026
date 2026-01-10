using System.Text;

namespace WebMVC.Filters
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        // 建構函數注入
        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // 處理請求的方法
        public async Task InvokeAsync(HttpContext context)
        {
            // 記錄請求資訊
            Console.WriteLine($"HTTP Method:{context.Request.Method},Path:{context.Request.Path} 請求開始處理 - {DateTime.Now}");

            /*
             * HttpContext.Request.Body 是什麼？
             * 在 ASP.NET Core 中，context.Request.Body 是一個 Stream，代表「HTTP 請求的原始內容」。
             * 但這不是字串，也不是 JSON，你必須用程式去「讀取」這個 stream，才能拿到裡面的內容。
             * ASP.NET Core 不會自動幫你解析 Request.Body 的內容，尤其在 Middleware 裡，不像 Controller 有 Model Binding。             
             */

            // 1. 讓 Request.Body 可以被多次讀取（重要！）
            context.Request.EnableBuffering();

            // 2. 移動指標回起點
            context.Request.Body.Position = 0;

            // 3. 讀取 stream 成字串
            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
            string bodyString = await reader.ReadToEndAsync();

            // 4. 再次把指標設為起點，讓後面還能用 Request.Body
            context.Request.Body.Position = 0;

            // 可以印出來，或做 Log持久化記錄
            Console.WriteLine($"Request Body: {bodyString}");

            // 呼叫管道中的下一個 middleware
            await _next(context);

            // 請求處理完成後記錄狀態碼
            Console.WriteLine($"請求完成 狀態碼 {context.Response.StatusCode},HTTP Method:{context.Request.Method},Path:{context.Request.Path} 請求結束處理 - {DateTime.Now}");
        }
    }
}
