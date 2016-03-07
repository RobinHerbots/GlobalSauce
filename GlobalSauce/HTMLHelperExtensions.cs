using System.Text;
using System.Web.Mvc;
using GlobalSauce.Enums;

namespace GlobalSauce
{
    public static class HTMLHelperExtensions
    {
        public static MvcHtmlString GlobalSauce(this HtmlHelper htmlHelper, bool addClosure, params Components[] components)
        {
            var cultureModel = new StringBuilder();

            foreach (var component in components)
            {
                cultureModel.AppendLine(RenderTargetProcessor.Render(component));
            }

            return addClosure ? new MvcHtmlString($"(function($) {{{cultureModel}}})(jQuery);") : new MvcHtmlString(cultureModel.ToString());
        }
    }
}
