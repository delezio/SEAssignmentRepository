using System.Web;
using System.Web.Mvc;

namespace SteveDelezioSEAssignment2Sit1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
