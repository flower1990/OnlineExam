using ComputerRankExam.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Areas.Member.Controllers
{
    [IsLogin]
    public class MenuController : Controller
    {
        //
        // GET: /Member1/Menu/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserMenu()
        {
            return View();
        }

        public ActionResult CardMenu()
        {
            return View();
        }
    }
}
