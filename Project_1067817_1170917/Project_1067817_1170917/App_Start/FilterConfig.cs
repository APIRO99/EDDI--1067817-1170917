using System.Web;
using System.Web.Mvc;

namespace Project_1067817_1170917
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
