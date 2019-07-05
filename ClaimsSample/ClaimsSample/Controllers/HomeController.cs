using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClaimsSample.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClaimsSample.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Policy ="OnlyForLondon")]
        public IActionResult Index()
        {
            return View();
        }
     
        [Authorize(Policy = "OnlyForMicrosoft")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
 
            return View();
        }
    }
}
