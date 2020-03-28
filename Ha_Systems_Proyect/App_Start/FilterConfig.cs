using System.Web;
using System.Web.Mvc;

namespace Ha_Systems_Proyect
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
