using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMVC.Controllers
{
    /// <summary>
    /// TagHelper 教學 Controller
    /// 展示 ASP.NET Core 中各種 TagHelper 的使用方式
    /// </summary>
    public class TagHelperTutorialController : BaseController
    {
        private readonly ILogger<TagHelperTutorialController> _logger;

        public TagHelperTutorialController(ILogger<TagHelperTutorialController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// TagHelper 教學首頁
        /// </summary>
        public IActionResult Index()
        {
            // 為下拉選單準備資料
            ViewBag.Countries = new List<SelectListItem>
            {
                new SelectListItem { Value = "TW", Text = "台灣" },
                new SelectListItem { Value = "JP", Text = "日本" },
                new SelectListItem { Value = "US", Text = "美國" },
                new SelectListItem { Value = "UK", Text = "英國" }
            };

            ViewBag.Categories = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "電子產品" },
                new SelectListItem { Value = "2", Text = "服飾" },
                new SelectListItem { Value = "3", Text = "食品" },
                new SelectListItem { Value = "4", Text = "書籍" }
            };

            return View();
        }

        /// <summary>
        /// 表單提交範例
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormSubmit(string username, string email, string country)
        {
            TempData["Message"] = $"表單已提交！使用者：{username}，Email：{email}，國家：{country}";
            return RedirectToAction(nameof(Index));
        }
    }
}
