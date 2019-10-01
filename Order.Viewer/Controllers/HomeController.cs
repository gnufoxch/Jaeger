using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Mvc;
using Order.Viewer.Models;

namespace Order.Viewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrderInfoLogic orderLogic = new OrderInfoLogic();
        public IActionResult Index()
        {
            return View(orderLogic.GetCompleteList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //POST - FILTER
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult Filter(DateTime date)
        {
            var orders = orderLogic.GetCompleteList();

            var list = orders.Where(x => x.InsertDate.Day == date.Day &&
                                         x.InsertDate.Month == date.Month &&
                                         x.InsertDate.Year == date.Year).ToList();
            return View(list);
        }
    }
}
