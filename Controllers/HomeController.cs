using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyCvAndTaxApp.Models;

namespace MyCvAndTaxApp.Controllers
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
        public IActionResult Education() => View();
        public IActionResult Experience() => View();
        public IActionResult Skills() => View();
        public IActionResult Projects() => View();
        public IActionResult TaxCalculator() => View();
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult TaxCalculator(double income)
        {
            double tax = CalculateNigeriaTax(income);
            ViewBag.Tax = tax;
            return View();
        }

        private double CalculateNigeriaTax(double income)
        {
            // Nigeria's tax brackets (simplified)
            if (income <= 300000) return income * 0.07;
            if (income <= 600000) return 21000 + (income - 300000) * 0.11;
            if (income <= 1100000) return 54000 + (income - 600000) * 0.15;
            if (income <= 1600000) return 129000 + (income - 1100000) * 0.19;
            if (income <= 3200000) return 224000 + (income - 1600000) * 0.21;
            return 560000 + (income - 3200000) * 0.24;
        }
    }
}
