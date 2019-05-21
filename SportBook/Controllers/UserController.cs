using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportBook.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserMain()
        {
            return View();
        }
        
        public IActionResult UserProfileWindow()
        {
            return View();
        }
    }
}