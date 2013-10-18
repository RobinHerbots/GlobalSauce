using System;
using System.Text;
using System.Web.Mvc;
using GlobalSauce.Enums;
using GlobalSauce.Rendertargets;

namespace GlobalSauce
{
    public static class HTMLHelperExtensions
    {
        public static MvcHtmlString GlobalSauce(this HtmlHelper htmlHelper, params Components[] components)
        {
            var cultureModel = new StringBuilder();

            cultureModel.AppendLine("(function($) {");

            foreach (var component in components)
            {
                cultureModel.AppendLine(RenderTargetProcessor.Render(component));
            }
            
            cultureModel.AppendLine("})(jQuery);");

            return new MvcHtmlString(cultureModel.ToString());
        }
    }
}
