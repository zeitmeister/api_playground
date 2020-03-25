using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Treehouse.AspNetCore.Models;
using Treehouse.AspNetCore.Services;
using Treehouse.AspNetCore.ViewModels.AuthModel;

namespace Treehouse.AspNetCore.Controllers
{
    public class HomeController : Controller
    {

        private ITestService _testService = null;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ITestService testService)
        {
            _testService = testService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _testService.GetAboutContent();
            ViewBag.Message = _testService.GetAboutContent();

            return View();
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
