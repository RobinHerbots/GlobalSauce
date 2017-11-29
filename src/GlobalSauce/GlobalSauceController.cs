using System;
using System.Web.Mvc;
using GlobalSauce.Enums;

namespace GlobalSauce
{
    [AllowAnonymous]
    public class GlobalSauceController : Controller
    {
        [HttpGet]
        public virtual JavaScriptResult Get(string id)
        {
            Components component;
            if (Enum.TryParse(id.Replace(".js", ""), out component))
                return JavaScript(RenderTargetProcessor.Render(component));

            return new JavaScriptResult();
        }
    }
}