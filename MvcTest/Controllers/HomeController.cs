using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcTest.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace MvcTest.Controllers
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

        public ChartModel GetSales()
        {
            var m = new ChartModel();
            m.Title = "Bars Example";
            m.SubTitle = "Sales";
            //m.Legend.Add("Sales");
            List<SalesData> data = GetSalesData();
            foreach (var r in data)
            {
                m.Series.Add(new SeriesRec() { name = r.ItemName, value = r.TotalAmount.ToString() });
            }
            return m;
        }
        private List<SalesData> GetSalesData()
        {
            List<SalesData> sales = new List<SalesData>();
            sales.Add(new SalesData() { ItemName = "Shirts", TotalAmount = 5 });
            sales.Add(new SalesData() { ItemName = "Cardigans", TotalAmount = 20 });
            sales.Add(new SalesData() { ItemName = "Chiffons", TotalAmount = 36 });
            sales.Add(new SalesData() { ItemName = "Pants", TotalAmount = 10 });
            sales.Add(new SalesData() { ItemName = "Heels", TotalAmount = 12 });
            sales.Add(new SalesData() { ItemName = "Socks", TotalAmount = 20 });
            return sales;
        }

        public ChartModel GetAccessFrom()
        {
            var m = new ChartModel();
            m.Title = "Pie Example";
            m.SubTitle = "Access From";            
            List<AccessFromData> data = GetAccessFromData();
            foreach(var r in data)
            {
                m.Series.Add(new SeriesRec() { name = r.Item, value = r.Count.ToString() });
            }
            return m;
        }

        private List<AccessFromData> GetAccessFromData()
        {
            List<AccessFromData> sales = new List<AccessFromData>();
            sales.Add(new AccessFromData() { Item = "Search Engine", Count = 1048 });
            sales.Add(new AccessFromData() { Item = "Direct", Count = 735 });
            sales.Add(new AccessFromData() { Item = "Email", Count = 580 });
            sales.Add(new AccessFromData() { Item = "Union Ads", Count = 484 });
            sales.Add(new AccessFromData() { Item = "Video Ads", Count = 300 });
            return sales;
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
