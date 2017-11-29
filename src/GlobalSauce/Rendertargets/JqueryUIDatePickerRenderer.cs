using System;
using System.Globalization;
using System.Text;
using GlobalSauce.Enums;

namespace GlobalSauce.Rendertargets
{
    internal class JqueryUIDatePickerRenderer : IRenderTarget
    {
        public string Render(CultureInfo cultureInfo, CultureInfo uicultureInfo)
        {
            var datepickerCulture = new StringBuilder();
            datepickerCulture.AppendLine("(function(factory) {");
            datepickerCulture.AppendLine("if (typeof define === \"function\" && define.amd)");
            datepickerCulture.AppendLine("{");
            datepickerCulture.AppendLine("define([\"jquery\", \"jquery-ui/datepicker\"], factory);");
            datepickerCulture.AppendLine("}");
            datepickerCulture.AppendLine("else {");
            datepickerCulture.AppendLine("factory(jQuery);");
            datepickerCulture.AppendLine("}");
            datepickerCulture.AppendLine("}");
            datepickerCulture.AppendLine("(function($) {");
            datepickerCulture.AppendFormat("$.datepicker.regional[\"{0}\"] = {{\n", cultureInfo.Name);
            datepickerCulture.AppendFormat("closeText: \"{0}\",\n", Resources.JqueryUIDatePicker.closeText);
            datepickerCulture.AppendFormat("prevText: \"{0}\",\n", Resources.JqueryUIDatePicker.prevText);
            datepickerCulture.AppendFormat("nextText: \"{0}\",\n", Resources.JqueryUIDatePicker.nextText);
            datepickerCulture.AppendFormat("currentText: \"{0}\",\n", Resources.JqueryUIDatePicker.currentText);
            datepickerCulture.AppendFormat(
                "monthNames: [\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\"],\n",
                uicultureInfo.DateTimeFormat.MonthNames[(int) MonthOfYear.January - 1],
                uicultureInfo.DateTimeFormat.MonthNames[(int) MonthOfYear.February - 1],
                uicultureInfo.DateTimeFormat.MonthNames[(int) MonthOfYear.March - 1],
                uicultureInfo.DateTimeFormat.MonthNames[(int) MonthOfYear.April - 1],
                uicultureInfo.DateTimeFormat.MonthNames[(int) MonthOfYear.May - 1],
                uicultureInfo.DateTimeFormat.MonthNames[(int) MonthOfYear.June - 1],
                uicultureInfo.DateTimeFormat.MonthNames[(int) MonthOfYear.July - 1],
                uicultureInfo.DateTimeFormat.MonthNames[(int) MonthOfYear.August - 1],
                uicultureInfo.DateTimeFormat.MonthNames[(int) MonthOfYear.September - 1],
                uicultureInfo.DateTimeFormat.MonthNames[(int) MonthOfYear.October - 1],
                uicultureInfo.DateTimeFormat.MonthNames[(int) MonthOfYear.November - 1],
                uicultureInfo.DateTimeFormat.MonthNames[(int) MonthOfYear.December - 1]
                );
            datepickerCulture.AppendFormat(
                "monthNamesShort:  [\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\"],\n",
                uicultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int) MonthOfYear.January - 1],
                uicultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int) MonthOfYear.February - 1],
                uicultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int) MonthOfYear.March - 1],
                uicultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int) MonthOfYear.April - 1],
                uicultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int) MonthOfYear.May - 1],
                uicultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int) MonthOfYear.June - 1],
                uicultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int) MonthOfYear.July - 1],
                uicultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int) MonthOfYear.August - 1],
                uicultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int) MonthOfYear.September - 1],
                uicultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int) MonthOfYear.October - 1],
                uicultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int) MonthOfYear.November - 1],
                uicultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int) MonthOfYear.December - 1]
                );
            datepickerCulture.AppendFormat("dayNames: [\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\"],\n",
                uicultureInfo.DateTimeFormat.DayNames[(int) DayOfWeek.Sunday],
                uicultureInfo.DateTimeFormat.DayNames[(int) DayOfWeek.Monday],
                uicultureInfo.DateTimeFormat.DayNames[(int) DayOfWeek.Tuesday],
                uicultureInfo.DateTimeFormat.DayNames[(int) DayOfWeek.Wednesday],
                uicultureInfo.DateTimeFormat.DayNames[(int) DayOfWeek.Thursday],
                uicultureInfo.DateTimeFormat.DayNames[(int) DayOfWeek.Friday],
                uicultureInfo.DateTimeFormat.DayNames[(int) DayOfWeek.Saturday]
                );
            datepickerCulture.AppendFormat(
                "dayNamesShort: [\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\"],\n",
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Sunday],
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Monday],
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Tuesday],
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Wednesday],
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Thursday],
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Friday],
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Saturday]
                );
            datepickerCulture.AppendFormat("dayNamesMin: [\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\"],\n",
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Sunday][0],
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Monday][0],
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Tuesday][0],
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Wednesday][0],
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Thursday][0],
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Friday][0],
                uicultureInfo.DateTimeFormat.AbbreviatedDayNames[(int) DayOfWeek.Saturday][0]
                );
            datepickerCulture.AppendFormat("weekHeader: \"{0}\",\n", Resources.JqueryUIDatePicker.weekHeader);
            datepickerCulture.AppendFormat("dateFormat: \"{0}\",\n", cultureInfo.DateTimeFormat.JqueryUIDateFormat());
            datepickerCulture.AppendFormat("firstDay: {0},\n", (int) cultureInfo.DateTimeFormat.FirstDayOfWeek);
            datepickerCulture.AppendFormat("isRTL: {0},\n",
                cultureInfo.TextInfo.IsRightToLeft.ToString().ToLowerInvariant());
            datepickerCulture.AppendFormat("showMonthAfterYear: {0},\n", Resources.JqueryUIDatePicker.showMonthAfterYear);
            datepickerCulture.AppendFormat("yearSuffix: \"{0}\"\n", Resources.JqueryUIDatePicker.yearSuffix);
            datepickerCulture.AppendLine("};");
            datepickerCulture.AppendFormat("$.datepicker.setDefaults($.datepicker.regional[\"{0}\"]);\n",
                cultureInfo.Name);
            datepickerCulture.AppendLine("}));");
            return datepickerCulture.ToString();
        }
    }


    public static partial class DateFormatInfoExtensions
    {
        public static string JqueryUIDateFormat(this DateTimeFormatInfo dateTimeFormatInfo)
        {
            var dfs = dateTimeFormatInfo.ShortDatePattern.ToLowerInvariant().Split(new[] { dateTimeFormatInfo.DateSeparator }, StringSplitOptions.None);
            var jqUIFormat = new StringBuilder();
            jqUIFormat.AppendFormat(dfs[0].Length < 4 ? "{0}{1}" : "{0}{0}{1}", dfs[0][0], dateTimeFormatInfo.DateSeparator);
            jqUIFormat.AppendFormat(dfs[1].Length < 4 ? "{0}{1}" : "{0}{0}{1}", dfs[1][0], dateTimeFormatInfo.DateSeparator);
            jqUIFormat.AppendFormat(dfs[2].Length < 4 ? "{0}" : "{0}{0}", dfs[2][0]);

            return jqUIFormat.ToString();
        }
    }
}
