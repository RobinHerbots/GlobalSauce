using System.Globalization;
using System.Threading;
using GlobalSauce.Enums;
using GlobalSauce.Rendertargets;

namespace GlobalSauce
{
    public class RenderTargetProcessor
    {
        public static string Render(Components component)
        {
            IRenderTarget renderTarget;
            switch (component)
            {
                case Components.JqGrid:
                    renderTarget = new JqGridRenderer();
                    break;
                case Components.JqueryGlobalization:
                    renderTarget = new JqueryGlobalizationRenderer();
                    break;
                case Components.JqueryUIDatePicker:
                    renderTarget = new JqueryUIDatePickerRenderer();
                    break;
                case Components.JqueryUITimePicker:
                    renderTarget = new JqueryUITimePickerRenderer();
                    break;
                case Components.ckeditor:
                    renderTarget = new ckeditorRenderer();
                    break;

                default:
                    renderTarget = new EmptyRenderer();
                    break;
            }

            return renderTarget.Render(Thread.CurrentThread.CurrentCulture, Thread.CurrentThread.CurrentUICulture);
        }
    }

    public interface IRenderTarget
    {
        string Render(CultureInfo cultureInfo, CultureInfo uicultureInfo);
    }

    public class EmptyRenderer : IRenderTarget
    {
        public string Render(CultureInfo cultureInfo, CultureInfo uicultureInfo)
        {
            return string.Empty;
        }
    }
}
