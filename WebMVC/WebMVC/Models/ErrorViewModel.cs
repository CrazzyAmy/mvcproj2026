namespace WebMVC.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        /// <summary>
        /// 錯誤標題
        /// </summary>
        public string? ErrorTitle { get; set; }

        /// <summary>
        /// 顯示給使用者的錯誤訊息
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// 詳細錯誤資訊（僅開發環境顯示）
        /// </summary>
        public string? ErrorDetails { get; set; }

        /// <summary>
        /// 返回的連結 URL
        /// </summary>
        public string? ReturnUrl { get; set; }

        /// <summary>
        /// 返回連結的文字
        /// </summary>
        public string? ReturnText { get; set; }

        /// <summary>
        /// 是否有自訂錯誤訊息
        /// </summary>
        public bool HasCustomError => !string.IsNullOrEmpty(ErrorMessage);
    }
}
