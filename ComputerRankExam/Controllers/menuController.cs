using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerRankExam.Models;
using Sower.Business;
using Sower.Model;

namespace ComputerRankExam.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /menu/
        [ChildActionOnly]
        public ActionResult IndexNav(string id)
        {
            NavigateViewModel viewModel = new NavigateViewModel();
            if (id == "0")
            {
                viewModel.css_index = "active";
            }
            else
            {
                viewModel.css_index = "";
            }

            if (id == "1")
            {
                viewModel.css_1 = "active";
            }
            else
            {
                viewModel.css_1 = "";
            }

            if (id == "2")
            {
                viewModel.css_2 = "active";
            }
            else
            {
                viewModel.css_2 = "";
            }

            if (id == "3")
            {
                viewModel.css_3 = "active";
            }
            else
            {
                viewModel.css_3 = "";
            }

            if (id == "4")
            {
                viewModel.css_4 = "active";
            }
            else
            {
                viewModel.css_4 = "";
            }

            if (id == "5")
            {
                viewModel.css_5 = "active";
            }
            else
            {
                viewModel.css_5 = "";
            }

            if (id == "6")
            {
                viewModel.css_6 = "active";
            }
            else
            {
                viewModel.css_6 = "";
            }

            BLL_ExamType bll = new BLL_ExamType();
            T_ExamType model = bll.GetExamType("1");
            viewModel.ExamDomain = model.ExamDomain;
            return View(viewModel);
        }
    }
}
