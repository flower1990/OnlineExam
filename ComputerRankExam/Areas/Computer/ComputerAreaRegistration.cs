using System.Web.Mvc;

namespace ComputerRankExam.Areas.Computer
{
    public class ComputerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Computer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Computer_default",
                "Computer/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "ComputerRankExam.Areas.Computer.Controllers" }
            );

            context.MapRoute(
                "Computer_page",
                "Computer/{controller}/{action}/{id}/{page}",
                new { action = "Index", id = UrlParameter.Optional, page = UrlParameter.Optional },
                new string[] { "ComputerRankExam.Areas.Computer.Controllers" }
            );
        }
    }
}
