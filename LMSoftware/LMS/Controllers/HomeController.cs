using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LMS.Models;
using LMS.Data.Interfaces;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repo;
        private readonly ITestRepository _testRepo;

        public HomeController(ILogger<HomeController> logger, IRepository repo, ITestRepository testrepo)
        {
            _logger = logger;
            _repo = repo;
            _testRepo = testrepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Doctor()
        {
           var doc = _repo.GetAllPhysicians();
            return View(doc);
        }
        public IActionResult Department()
        {
            var dept = _testRepo.GetAllDepartments();
            return View(dept);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
