using System.Web;
using System.Web.Mvc;

namespace NeshStudios.Games.Beerpong
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}