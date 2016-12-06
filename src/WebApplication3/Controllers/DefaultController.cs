using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    public class DefaultController : Controller
    {
        //[HttpGet("/")]
        //public string Index() => "Hello from MVC!";

         //[HttpGet("/Maria")]
        public string abc() => "Hello from abc!";



        public IActionResult Index()
        {
            return View();
        }
    }
    public class JackController:Controller
    {
        public IActionResult Index() {
            return View();
        }
        public string abc() => "Hello from Jack";
    }
}
