using ComputerRankExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TestViewModel test)
        {
            if (ModelState.IsValid)
            {
                Response.Write("验证通过");
            }
            Response.Write("验证不通过");
            return View(test);
        }
    }
}
