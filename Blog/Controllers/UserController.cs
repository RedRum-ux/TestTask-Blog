using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;

namespace Blog.Controllers
{
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
