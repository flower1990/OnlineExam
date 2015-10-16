using ComputerRankExam.Areas.Computer.Models;
using Sower.Business;
using Sower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Areas.Computer.Controllers
{
    public class MenuController : Controller
    {
        [ChildActionOnly]
        public ActionResult Navigate(string id)
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

            if (id == "2" || id == "1" || id == "6" || id == "7")
            {
                viewModel.css_1 = "active";
            }
            else
            {
                viewModel.css_1 = "";
            }

            if (id == "3")
            {
                viewModel.css_2 = "active";
            }
            else
            {
                viewModel.css_2 = "";
            }

            if (id == "11")
            {
                viewModel.css_3 = "active";
            }
            else
            {
                viewModel.css_3 = "";
            }

            if (id == "88")
            {
                viewModel.css_4 = "active";
            }
            else
            {
                viewModel.css_4 = "";
            }

            if (id == "4" || id == "5" || id == "8")
            {
                viewModel.css_5 = "active";
            }
            else
            {
                viewModel.css_5 = "";
            }

            if (id == "100")
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
