using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalculatorApp.Models;

namespace CalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Calculator cal) {
            float first, second;

            first = cal.value1;
            second = cal.value2;

            switch (cal.operation)
            {
                case "+":
                    cal.result = first + second;
                    break;
                case "-":
                    cal.result = first - second;
                    break;
                case "x":
                    cal.result = first * second;
                    break;
                case "/":
                    cal.result = first / second;
                    break;
                case "Sqrt":
                    cal.result = (float)Math.Sqrt(first);
                    break;
                case "Pow":
                    cal.result = (float)Math.Pow(first, second);
                    break;
                case "Sin":
                    first = (float)(first / 180 * Math.PI);
                    cal.result = (float)Math.Sin(first);
                    break;
                case "Cos":
                    first = (float)(first / 180 * Math.PI);
                    cal.result = (float)Math.Cos(first);
                    break;
                case "Tan":
                    first = (float)(first / 180 * Math.PI);
                    cal.result = (float)Math.Tan(first);
                    break;
            }

            ViewData["result"] = cal.result;
            
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
