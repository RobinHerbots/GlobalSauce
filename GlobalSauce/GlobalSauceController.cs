using System.Web.Http;
using System.Web.Mvc;
using GlobalSauce.Enums;

namespace GlobalSauce
{
    public class GlobalSauceController : Controller
    {
        public JsonResult Get(Components component)
        {
            return Json(new MvcHtmlString($"(function($) {{{RenderTargetProcessor.Render(component)}}})(jQuery);"));
        }
    }
}