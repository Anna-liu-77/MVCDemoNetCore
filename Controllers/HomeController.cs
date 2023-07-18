using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCDemoNetCore.Interface;
using MVCDemoNetCore.Models;
using System.Diagnostics;

namespace MVCDemoNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepository _studentRepository;

        public HomeController(ILogger<HomeController> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        // 学生详情页
        //public JsonResult Details(int? id)
        //{
        //    var stu = _studentRepository.GetStudent(id??1);
        //    return Json(stu);
        //}
        public IActionResult Details(int? id)
        {
            var stu = _studentRepository.GetStudent(id ?? 1);
            return View(stu);
        }

        // 新增学生页
        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public RedirectToActionResult CreateStudent(Student student)
        {
            _studentRepository.Add(student);
            return RedirectToAction("Details",new { id = student.Id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}