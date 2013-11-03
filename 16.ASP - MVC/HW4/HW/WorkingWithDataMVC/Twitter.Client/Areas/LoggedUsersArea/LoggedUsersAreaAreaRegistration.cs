using System.Web.Mvc;

namespace Twitter.Client.Areas.LoggedUsersArea
{
    public class LoggedUsersAreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "LoggedUsersArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "LoggedUsersArea_default",
                "LoggedUsersArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
