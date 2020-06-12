using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZooCalculationBussinesLogic.Interfaces;
using ZooCalculationDatabaseImplements.Implements;

namespace ZooCalculationWebClient.Controllers
{
    public class RouteController : Controller
    {
        private readonly IRouteLogic course;
        public RouteController(RouteLogic course)
        {
           this.course = course;
        }
        public IActionResult Route()
        {
            ViewBag.Routes = course.Read(null);
            return View();
        }
    }
}
