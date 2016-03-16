using System;
using System.Globalization;
using System.Text;
using System.Threading;
using GlobalSauce;
using GlobalSauce.Enums;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-BE");

            var cultureModel = new StringBuilder();
            cultureModel.AppendLine(RenderTargetProcessor.Render(Components.JqueryGlobalization));
            Console.WriteLine(cultureModel.ToString());

            Console.ReadKey();
        }
    }
}
