using ComputerRankExam.App_Start;
using ComputerRankExam.Areas.Computer.Models;
using ComputerRankExam.Filters;
using Sower.Business;
using Sower.CommFunction;
using Sower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Areas.Computer.Controllers
{
    public class HomeController : Controller
    {
        private int PageSize = 20;
        private string ExamTypeID = SysFun.ExamTypID.ToString();
        private BLL_Article bll = new BLL_Article();
        private static BLL_ExamType tbll = new BLL_ExamType();
        private string ExamDomain = tbll.GetExamType("1").ExamDomain;
        //
        // GET: /Columns/
        public ActionResult Index()
        {
            BLL_Product pbll = new BLL_Product();
            BLL_ExamFile filebll = new BLL_ExamFile();
            IndexViewModel viewModel = new IndexViewModel();
            string where = " and ExamTypeID=" + ExamTypeID;
            viewModel.useHelpArticle = bll.GetArticleModels(where + " and ColumnId=5 order by Id", "4");
            viewModel.newsArticle = bll.GetArticleModels(where + " and ColumnId in(1,2,6,7) order by Id desc", "6");
            viewModel.reviewGuidArticle = bll.GetArticleModels(where + " and ColumnId=3 order by Id desc", "9");
            viewModel.examinationCenterArticle = bll.GetArticleModels(where + " and ColumnId=10 order by Id desc", "9");
            viewModel.ExamNewsArticle = bll.GetArticleModels(where + " and ColumnId=2 order by Id desc", "10");
            viewModel.TopOnePicArticle = bll.GetArticleModels(where + " and ColumnId=2 and Thumbnail<>''", "1");
            viewModel.SignUpEntry = bll.GetArticleModels(where + "and ColumnId=13", "20");
            //viewModel.productInfo = filebll.GetExamFileList(" where ",8)
            viewModel.downLoadFile = filebll.GetExamFileList(" Disuse=0 and ExamTypeID=" + ExamTypeID, 5);
            viewModel.phone = SysFun.phone;
            ViewBag.Title = "首页";
            ViewBag.currentID = 0;
            ViewBag.ExamDomain = ExamDomain;

            return View(viewModel);
        }
        public ActionResult List(string id, int page = 1)
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

            if (!bll.isExistsColumnID(columnid.ToString()))
            {
                return RedirectToAction("index", "Error");
            }
            int TotalCount = 0;
            string where = " ColumnId=" + columnid;
            List<T_Article> articles = bll.GetPageArticleModels(PageSize, page, ExamTypeID, where, false, ref TotalCount);
            ColumnsListViewModel viewModel = new ColumnsListViewModel();
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
            ViewBag.currentID = id;
            viewModel.phone = SysFun.phone;
            return View(viewModel);
        }
        [ChildActionOnly]
        public ViewResult Left()
        {
            string where = " and ExamTypeID=" + ExamTypeID + " and ColumnId=5";
            string where1 = " and ExamTypeID=" + ExamTypeID + " and ColumnId=6";
            LeftViewModel viewModel = new LeftViewModel();
            viewModel.userHelpArticles = bll.GetArticleModels(where, "4");
            viewModel.zhinanArticles = bll.GetArticleModels(where1, "8");
            viewModel.phone = SysFun.phone;
            return View(viewModel);
        }
        public ActionResult Detail(string id)
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
            DetailViewModel model = new DetailViewModel();
            model.ArticleModel = bll.GetModel(articleid);
            ViewBag.Title = model.ArticleModel.Title + "-" + model.ArticleModel.ColumnTitle;
            model.phone = SysFun.phone;
            return View(model);
        }
        public ActionResult DownLoad()
        {
            DownLoadViewModel viewModel = new DownLoadViewModel();
            BLL_ExamFile fbll = new BLL_ExamFile();
            viewModel.downloadfiles = fbll.GetExamFileList(" Disuse=0 and ExamTypeID=" + ExamTypeID, 0);
            ViewBag.currentID = 88;
            viewModel.phone = SysFun.phone;
            return View(viewModel);
        }
        [IsLoginAttribute]
        public ActionResult DownLoadFile(string id)
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
                return RedirectToAction("NoFound", "Error");
            }

        }
        [IsLoginAttribute]
        public ActionResult Message()
        {
            MessageViewModel viewModel = new MessageViewModel();
            ViewBag.sUrl = ExamDomain;
            return View(viewModel);
        }
        [IsLoginAttribute]
        [HttpPost]
        public ActionResult Message(MessageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (Session["ValidateCode"] != null && viewModel.ValidCode.ToLower() != Session["ValidateCode"].ToString().ToLower())
                {
                    ModelState.AddModelError("ValidCode", "验证码输入不正确");
                    return View();
                }
                //过滤危险字符串
                if (FilterClass.FilterSqlStringX(viewModel.sname) || FilterClass.FilterSqlStringX(viewModel.Phone) || FilterClass.FilterSqlStringX(viewModel.QQ) || FilterClass.FilterSqlStringX(viewModel.Email) || FilterClass.FilterSqlStringX(viewModel.stitle) || FilterClass.FilterSqlStringX(viewModel.content))
                {
                    ViewBag.Message = "请不要进行非法请求";
                    return View("~/Views/Error/ErrorSql.cshtml");
                }
                BLL_UserFeedback ubll = new BLL_UserFeedback();
                if (ubll.IsNopassMessage(CheckLogin.CookieCode()) > 0)
                {
                    ViewBag.Message = "您有留言待审核通过，暂时无法签写留言！";
                    return View("~/Views/Error/ErrorSql.cshtml");
                }
                T_UserFeedback entity = new T_UserFeedback();
                entity.Name = viewModel.sname;
                entity.UserCode = CheckLogin.CookieCode();
                entity.Phone = viewModel.Phone;
                entity.QQ = viewModel.QQ;
                entity.Email = viewModel.Email;
                entity.Title = viewModel.stitle;
                entity.Content = viewModel.content;
                entity.Approved = false;
                entity.CreateDate = DateTime.Now;
                ViewBag.sUrl = ExamDomain;
                try
                {
                    ubll.AddFeedback(entity);
                }
                catch
                {
                    //写日志

                }
                ViewBag.Message = "签写留言成功，需要审核通过！";
                return View("~/Views/Error/ErrorSql.cshtml");

            }
            else
            {
                return View(new MessageViewModel());
            }
        }
        public ActionResult MessageList(int id = 1, int page = 1)
        {
            BLL_UserFeedback bll = new BLL_UserFeedback();
            int totalCount = 0;
            MessageListViewModel viewModel = new MessageListViewModel();
            viewModel.messageList = bll.GetUserFeedbackListByPage(" Approved=1 ", page, PageSize, "UserFeedbackID", false, ref totalCount);
            viewModel.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = totalCount
            };
            ViewBag.sUrl = ExamDomain;
            ViewBag.currentID = 100;
            return View(viewModel);
        }
    }
}
