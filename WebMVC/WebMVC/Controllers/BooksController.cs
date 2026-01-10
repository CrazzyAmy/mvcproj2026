using Microsoft.AspNetCore.Mvc;
using WebMVC.Filters;
using WebMVC.Interface;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    //[ServiceFilter(typeof(AuthorizationFilter))] // 使用 ServiceFilter 套用授權驗證
    public class BooksController : BaseController
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //url: /Books/Index
        [HttpGet]
        public IActionResult Index()
        {
            //try
            //{
            //    var i = 1;
            //    var j = 0;
            //    var k = i / j; // 故意產生除以零的例外
            //}
            //catch (Exception ex)
            //{
            //    return HandleException(ex, "系統發生錯誤請回報開發單位");
            //}

            //var bookService = new BookService();
            //var books = bookService.GetAllBooks();
            var books = _bookService.GetAllBooks();

            // 設定 ViewBag 的 Title 屬性
            ViewBag.Title = "書本列表";
            ViewBag.Today = DateTime.Now;

            // 設定 ViewData 的 Description 屬性
            ViewData["Description"] = "這是書本列表頁面，展示所有書本的資訊。";

            // 設定 TempData 的 Message 屬性
            TempData["Today"] = DateTime.Now.ToString("yyyy-MM-dd");

            return View(books);
            //return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int id)
        {
            var books = _bookService.GetAllBooks().ToList().FindAll(b => b.Id == id);
            ViewBag.Id = id;
            return View(books);
        }

        //url: /Books/Create
        [HttpGet]
       [ServiceFilter(typeof(AuthorizationFilter))] // 使用 ServiceFilter 套用授權驗證
        public IActionResult Create()
        {
            return View();
        }

        // URL: /books/Create
        [HttpPost]
        // [ServiceFilter(typeof(AuthorizationFilter))] // 使用 ServiceFilter 套用授權驗證
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            try
            {
                _bookService.AddBook(book);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // 使用共用的 Exception 處理方法
                return HandleException(ex, "新增書籍時發生錯誤，請稍後再試。", "/Books", "返回書籍列表");
            }
        }

        // URL: /books/update/1
        [HttpGet]
        [Route("books/update/{id}")]
        public IActionResult Update(int id)
        {
            var book = _bookService.GetBook(id);
            if (book == null)
            {
                return ShowNotFound("書籍", id, "/Books", "返回書籍列表");
            }
            return View(book);
        }

        [HttpPost]
        [Route("books/update/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, BookViewModel book)
        {
            Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Price: {book.Price}");

            if (!ModelState.IsValid)
            {
                return View(book); // 返回帶有錯誤訊息的編輯畫面
            }

            _bookService.UpdateBook(book);
            return RedirectToAction(nameof(Index)); //回到列表頁
        }


        // URL: /book/delete/1
        [HttpGet("books/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetBook(id);
            if (book == null)
            {
                return ShowNotFound("書籍", id, "/Books", "返回書籍列表");
            }
            return View(book);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(BookViewModel book)
        {
            Console.WriteLine($"Id: {book.Id}");

            _bookService.DeleteBook(book.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
