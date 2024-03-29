﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MobileContext _db;
        
        public HomeController(MobileContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            return View(_db.Phones.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.PhoneId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();

            return "Спасибо, " + order.User + ", за покупку!";
        }
    }
}
