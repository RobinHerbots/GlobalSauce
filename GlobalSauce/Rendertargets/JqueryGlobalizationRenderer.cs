using System.Globalization;
using System.Threading;
using Globalization;

namespace GlobalSauce.Rendertargets
{
    internal class JqueryGlobalizationRenderer : IRenderTarget
    {
        public string Render(CultureInfo cultureInfo)
        {
            var globInfo = GlobalizationInfo.GetGlobInfo(cultureInfo);
            var diff = globInfo.ToDictionary(false);
            return GlobalizationInfo.GenerateJavaScript(string.Empty, string.Empty, cultureInfo, cultureInfo.Name, diff, null);
        }
    }
}