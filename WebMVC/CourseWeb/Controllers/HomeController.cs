using CourseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CourseService.Interface;
using Microsoft.AspNetCore.Authorization;


namespace CourseWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseScheduleService _csService;

        public HomeController(ILogger<HomeController> logger, ICourseScheduleService csService)
        {
            _logger = logger;
            _csService = csService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var vm = new List<CourseScheduleViewModel>();
            var models = await _csService.QueryAsync();

            foreach (var item in models)
            {
                vm.Add(new CourseScheduleViewModel
                {
                    Id = item.Id,
                    CourseCode = item.Code,
                    CourseName = item.Name,
                    TeacherName = item.TeacherName,
                    Times = item.Times,
                    Desc = item.Desc,
                    StartDate = item.Sdate,
                    EndDate = item.Edate,
                    Location = item.Location
                });
            }
            return View(vm);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
