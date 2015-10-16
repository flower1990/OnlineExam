using Sower.Business;
using Sower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Index()
        {
            BLL_ExamType bll = new BLL_ExamType();
            T_ExamType model = bll.GetExamType("2");
            ViewBag.ExamDomain = model.ExamDomain;

            return View();
        }

        public ActionResult NoFound()
        {
            BLL_ExamType bll = new BLL_ExamType();
            T_ExamType model = bll.GetExamType("2");
            ViewBag.ExamDomain = model.ExamDomain;

            return View();
        }
    }
}
