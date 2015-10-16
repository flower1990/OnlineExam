using System.Web.Mvc;
using Sower.Business;
using ComputerRankExam.Models;
using ComputerRankExam.App_Start;
using Sower.Model;
using Sower.CommFunction;
using System.Collections.Generic;

namespace ComputerRankExam.Controllers
{
    public class HomeController : Controller
    {
        private BLL_Article bl = new BLL_Article();
        private BLL_ExamFile filebl = new BLL_ExamFile();
        private BLL_ExamType ebll = new BLL_ExamType();
        private BLL_Article bll = new BLL_Article();
        private int PageSize = 23;
        private string ExamTypeID = SysFun.ExamTypID.ToString();

        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.ArticleList = bl.GetArticleModels(" and ExamTypeID=1 and ColumnId=5", "4");
            viewModel.ArticleList1 = bl.GetArticleModels(" and ExamTypeID=2 and ColumnId=5", "4");
            //viewModel.ArticleList2 = bl.GetArticleModels(" and ExamTypeID=3 and ColumnId=8", "4");
            viewModel.phone = SysFun.phone;
            viewModel.kjExamFile = filebl.GetExamFileList("  ExamTypeID=1 and Disuse=0", 0);
            viewModel.jsjExamFile = filebl.GetExamFileList(" ExamTypeID=2 and Disuse=0", 0);
            viewModel.ExamType = ebll.GetExamType("1");
            ViewBag.Title = "线上练习平台";
            ViewBag.currentID = 0;

            return View(viewModel);
        }
        /// <summary>
        /// 公司简介
        /// </summary>
        /// <returns></returns>
        public ActionResult Introduction()
        {
            ViewBag.currentID = 1;
            return View();
        }
        /// <summary>
        /// 新闻资讯
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult NewsInformation(string id, int page = 1)
        {
            int columnid;
            try
            {
                columnid = int.Parse(id);
            }
            catch
            {
                return RedirectToAction("index", "Error");
            }
            if (FilterClass.FilterSqlStringX(page.ToString()))
            {
                return RedirectToAction("index", "Error");
            }
            //if (id == "2")
            //{
            //    BLL_Product pbll = new BLL_Product();
            //    int TotalCount = 0;
            //    string where = " ColumnId=" + columnid;
            //    List<T_Product> articles = pbll.GetPageArticleModels(PageSize, page, ExamTypeID, where, false, ref TotalCount);
            //    ProductListViewModel viewModel = new ProductListViewModel();
            //    viewModel.prodcutList = articles;
            //    viewModel.PagingInfo = new PagingInfo
            //    {
            //        CurrentPage = page,
            //        ItemsPerPage = PageSize,
            //        TotalItems = TotalCount
            //    };
            //    viewModel.CurrentCategory = id;
            //    string columntitle = bll.GetColumnTitle(int.Parse(id));
            //    viewModel.ColumnTitle = columntitle;
            //    ViewBag.Title = columntitle;
            //    return View("~/Views/Columns/ProductList.cshtml",viewModel);
            //}
            //else
            //{
            if (!bll.isExistsColumnID(columnid.ToString()))
            {
                return RedirectToAction("index", "Error");
            }
            int TotalCount = 0;
            string where = " ColumnId=" + columnid;
            List<T_Article> articles = bll.GetPageArticleModels(PageSize, page, ExamTypeID, where, false, ref TotalCount);
            HomeViewModel viewModel = new HomeViewModel();

            viewModel.Articles = articles;
            viewModel.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = TotalCount
            };
            viewModel.CurrentCategory = id;
            string columntitle = bll.GetColumnTitle(int.Parse(id));
            viewModel.ColumnTitle = columntitle;
            ViewBag.Title = columntitle;
            ViewBag.currentID = 2;
            return View(viewModel);
        }

       

        public ActionResult Details(string id)
        {
            int articleid;
            try
            {
                articleid = int.Parse(id);
            }
            catch
            {
                return RedirectToAction("index", "Error");
            }
            if (!bll.isExistsArticleId(id))
            {
                return RedirectToAction("index", "Error");
            }
            HomeViewModel model = new HomeViewModel();
            model.ArticleModel = bll.GetModel(articleid);
            ViewBag.Title = model.ArticleModel.Title + "-" + model.ArticleModel.ColumnTitle;
            model.phone = SysFun.phone;

            return View(model);
        }
        public ActionResult DownloadCenter()
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.ExamFile = filebl.GetExamFileList("  Disuse=0", 0);
            viewModel.ExamType = ebll.GetExamType("1");
            ViewBag.Title = "线上练习平台";
            return View(viewModel);
        }
        public ActionResult DownloadCenterFiles(string id)
        {
            BLL_ExamFile fbll = new BLL_ExamFile();
            T_ExamFile model = fbll.GetModel(int.Parse(id));

            string path = System.AppDomain.CurrentDomain.BaseDirectory + @"OnlineSimulate_RES\ExamFile\";
            string fileName = path + model.SavePath.Replace(@"/", @"\") + model.FileRealName + "." + model.FileExt;
            if (System.IO.File.Exists(fileName))
            {
                return File(fileName, "application/octet-stream", model.FileShowName);
            }
            else
            {
                return RedirectToAction("IndexPage", "Home");
            }
        }

        public ActionResult ContactUs()
        {
            ViewBag.currentID = 4;
            return View();
        }

        [ChildActionOnly]
        public ActionResult subLogin()
        {
            if (CheckLogin.IsLogin())
            {
                BLL_LearnCard cbll = new BLL_LearnCard();
                //T_LearnCard model = cbll.GetCardModel(CheckLogin.CookieUserID());
                //ViewBag.UserName = model.Code;
                return View();
            }
            else
            {
                return View("~/Views/Home/subNoLogin.cshtml");
            }
        }

        public ActionResult Test()
        {
            return View();
        }

    }
}
