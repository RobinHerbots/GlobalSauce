using System;
using System.Globalization;
using System.Text;

namespace GlobalSauce.Rendertargets
{
    internal class JqueryUITimePickerRenderer : IRenderTarget
    {
        public string Render(CultureInfo cultureInfo)
        {
            var timepickerCulture = new StringBuilder();
            timepickerCulture.AppendFormat("$.timepicker.regional['{0}'] = {{\n", cultureInfo.Name);
            timepickerCulture.AppendFormat("timeOnlyTitle: '{0}',\n", Resources.JqueryUITimePicker.timeOnlyTitle);
            timepickerCulture.AppendFormat("timeText: '{0}',\n", Resources.JqueryUITimePicker.timeText);
            timepickerCulture.AppendFormat("hourText: '{0}',\n", Resources.JqueryUITimePicker.hourText);
            timepickerCulture.AppendFormat("minuteText: '{0}',\n", Resources.JqueryUITimePicker.minuteText);
            timepickerCulture.AppendFormat("secondText: '{0}',\n", Resources.JqueryUITimePicker.secondText);
            timepickerCulture.AppendFormat("millisecText: '{0}',\n", Resources.JqueryUITimePicker.millisecText);
            timepickerCulture.AppendFormat("microsecText: '{0}',\n", Resources.JqueryUITimePicker.microsecText);
            timepickerCulture.AppendFormat("timezoneText: '{0}',\n", Resources.JqueryUITimePicker.timezoneText);
            timepickerCulture.AppendFormat("currentText: '{0}',\n", Resources.JqueryUITimePicker.currentText);
            timepickerCulture.AppendFormat("closeText: '{0}',\n", Resources.JqueryUITimePicker.closeText);
            timepickerCulture.AppendFormat("timeFormat: '{0}',\n", cultureInfo.DateTimeFormat.JqueryUITimeFormat());
            timepickerCulture.AppendFormat("amNames: ['{0}'],\n", cultureInfo.TextInfo.ToUpper(cultureInfo.DateTimeFormat.AMDesignator));
            timepickerCulture.AppendFormat("pmNames: ['{0}'],\n", cultureInfo.TextInfo.ToUpper(cultureInfo.DateTimeFormat.PMDesignator));
            timepickerCulture.AppendFormat("isRTL: {0}\n", cultureInfo.TextInfo.IsRightToLeft.ToString().ToLowerInvariant());
            timepickerCulture.AppendLine("};");
            timepickerCulture.AppendFormat("$.timepicker.setDefaults($.timepicker.regional['{0}']);\n", cultureInfo.Name);

            return timepickerCulture.ToString();
        }
    }

    public static class TimeFormatInfoExtensions
    {
        public static string JqueryUITimeFormat(this DateTimeFormatInfo dateTimeFormatInfo)
        {
            var tfs = dateTimeFormatInfo.ShortTimePattern.Split(Convert.ToChar(dateTimeFormatInfo.TimeSeparator));
            var minSplit = tfs[1].Split(' ');

            return string.Format("{0}{0}{2}{1}{1}{3}", tfs[0][0].ToString().ToUpperInvariant(), minSplit[0][0], dateTimeFormatInfo.TimeSeparator, minSplit.Length > 1 ? " " + minSplit[1][0] : string.Empty);
        }
    }
}
