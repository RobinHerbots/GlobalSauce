using System.Web.Http;
using System.Web.Mvc;
using GlobalSauce.Enums;

namespace GlobalSauce
{
    public class GlobalSauceController : Controller
    {
        [HttpGet]
        public virtual JsonResult Get(Components id)
        {
            return Json(new MvcHtmlString($"(function($) {{{RenderTargetProcessor.Render(id)}}})(jQuery);"), JsonRequestBehavior.AllowGet);
        }
    }
}