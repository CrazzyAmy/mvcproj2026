using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Filters;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    /// <summary>
    /// 所有 Controller 的基底類別，提供共用的錯誤處理方法
    /// </summary>
    /// 
    [ServiceFilter(typeof(TimestampActionFilter))]
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// 顯示共用錯誤頁面
        /// </summary>
        /// <param name="errorMessage">錯誤訊息</param>
        /// <param name="errorTitle">錯誤標題（選填）</param>
        /// <param name="returnUrl">返回連結 URL（選填）</param>
        /// <param name="returnText">返回連結文字（選填）</param>
        /// <returns>Error View</returns>
        protected IActionResult ShowError(
            string errorMessage,
            string? errorTitle = null,
            string? returnUrl = null,
            string? returnText = null)
        {
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorTitle = errorTitle ?? "錯誤",
                ErrorMessage = errorMessage,
                ReturnUrl = returnUrl,
                ReturnText = returnText
            };

            return View("Error", errorViewModel);
        }

        /// <summary>
        /// 處理 Exception 並顯示錯誤頁面
        /// </summary>
        /// <param name="ex">Exception 物件</param>
        /// <param name="userFriendlyMessage">給使用者看的友善訊息</param>
        /// <param name="returnUrl">返回連結 URL（選填）</param>
        /// <param name="returnText">返回連結文字（選填）</param>
        /// <returns>Error View</returns>
        protected IActionResult HandleException(
            Exception ex,
            string? userFriendlyMessage = null,
            string? returnUrl = null,
            string? returnText = null)
        {
            // 取得環境變數判斷是否為開發環境
            var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorTitle = "系統錯誤",
                ErrorMessage = userFriendlyMessage ?? "系統發生錯誤，請稍後再試或聯繫系統管理員。",
                // 僅在開發環境顯示詳細錯誤
                ErrorDetails = isDevelopment ? $"{ex.GetType().Name}: {ex.Message}\n\nStackTrace:\n{ex.StackTrace}" : null,
                ReturnUrl = returnUrl,
                ReturnText = returnText
            };
           
            return View("Error", errorViewModel);
        }

        /// <summary>
        /// 顯示找不到資源的錯誤頁面
        /// </summary>
        /// <param name="resourceName">資源名稱</param>
        /// <param name="resourceId">資源 ID</param>
        /// <param name="returnUrl">返回連結 URL（選填）</param>
        /// <param name="returnText">返回連結文字（選填）</param>
        /// <returns>Error View</returns>
        protected IActionResult ShowNotFound(
            string resourceName,
            object? resourceId = null,
            string? returnUrl = null,
            string? returnText = null)
        {
            var message = resourceId != null
                ? $"找不到 {resourceName}（ID: {resourceId}）"
                : $"找不到指定的 {resourceName}";

            return ShowError(
                errorMessage: message,
                errorTitle: "找不到資源",
                returnUrl: returnUrl,
                returnText: returnText);
        }
    }
}
