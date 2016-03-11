using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using GlobalSauce.Enums;

namespace GlobalSauce
{
    public class GlobalSauceController : Controller
    {
        [HttpGet]
        public virtual JavaScriptResult Get(Components id)
        {
            return JavaScript(new MvcHtmlString($"(function($) {{{RenderTargetProcessor.Render(id)}}})(jQuery);").ToString());
        }
    }
}