using System.Web.Mvc;

namespace MicroB2c.Web.Areas.Admin
{
    internal static class RouteConfig
    {
        internal static void RegisterRoutes(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_Default",
                "Admin/{controller}/{action}/{id}",
                new {controller = "News", action = "Index", area = "Admin", id = ""},
                new[] { "MicroB2c.Web.Areas.Admin.Controllers" });
        }
    }
}