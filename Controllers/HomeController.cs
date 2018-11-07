//
//  Author:
//    Kristijan Klepač kristijan.klepac@gmail.com
//
//  Copyright (c) 2018, www.kristijanklepac.info
//
//  All rights reserved.
//
//
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapptesy.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
