﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Blog.Data;

namespace Blog.Controllers
{
    public class CategoryController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }
    }
}
