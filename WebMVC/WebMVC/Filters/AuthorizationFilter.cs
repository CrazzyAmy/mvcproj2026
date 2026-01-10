using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebMVC.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebMVC.Filters
{
    /// <summary>
    /// 授權驗證過濾器 - 實作 IAsyncAuthorizationFilter
    /// 當驗證失敗時，導向共用的 Error View
    /// 使用方式: [ServiceFilter(typeof(AuthorizationFilter))]
    /// </summary>
    public class AuthorizationFilter : IAsyncAuthorizationFilter
    {
        /// <summary>
        /// 模擬的授權 Role（實際應用中應從 Header、Cookie 或 Session 取得）
        /// </summary>
        private string ValidRole = "Admin";

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // 模擬非同步驗證過程
            await Task.Delay(10);

            var userRole = "User"; // 修改這裡來測試不同的授權結果

            // 模擬驗證邏輯
            bool isAuthenticated = userRole == ValidRole;

            if (!isAuthenticated)
            {
                // 驗證失敗，導向 Error View
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = context.HttpContext.TraceIdentifier,
                    ErrorTitle = "授權失敗",
                    ErrorMessage = "您沒有權限存取此資源，請先登入或確認您的權限。",
                    ReturnUrl = "/",
                    ReturnText = "返回首頁"
                };

                // 設定 Result 為 ViewResult，顯示共用的 Error View
                context.Result = new ViewResult
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary<ErrorViewModel>(
                        new EmptyModelMetadataProvider(),
                        new ModelStateDictionary())
                    {
                        Model = errorViewModel
                    }
                };

                // 設定 HTTP 狀態碼為 403 Forbidden
                context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            }
        }
    }
}
