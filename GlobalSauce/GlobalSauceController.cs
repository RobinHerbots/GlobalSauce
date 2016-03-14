using System;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using GlobalSauce.Enums;

namespace GlobalSauce
{
    [AllowAnonymous]
    public class GlobalSauceController : Controller
    {
        [HttpGet]
        public virtual JavaScriptResult Get(Components id)
        {
            return JavaScript(RenderTargetProcessor.Render(id));
        }
        [HttpGet]
        public virtual JavaScriptResult Get(string id)
        {
            Components component;
            if (Enum.TryParse(id.Remove(id.Length - ".js".Length), out component))
                return JavaScript(RenderTargetProcessor.Render(component));

            return new JavaScriptResult();
        }
    }
}