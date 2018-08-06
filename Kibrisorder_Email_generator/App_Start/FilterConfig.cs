using System.Web;
using System.Web.Mvc;

namespace Kibrisorder_Email_generator
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
