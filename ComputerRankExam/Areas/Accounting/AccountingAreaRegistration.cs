using System.Web.Mvc;

namespace ComputerRankExam.Areas.Accounting
{
    public class AccountingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Accounting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Accounting_default",
                "Accounting/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "ComputerRankExam.Areas.Accounting.Controllers" }
            );

            context.MapRoute(
                "Accounting_page",
                "Accounting/{controller}/{action}/{id}/{page}",
                new { action = "Index", id = UrlParameter.Optional, page = UrlParameter.Optional },
                new string[] { "ComputerRankExam.Areas.Accounting.Controllers" }
            );
        }
    }
}
