using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalSauce.Enums;

namespace GlobalSauce.Rendertargets
{
    internal class JqGridRenderer : IRenderTarget
    {
        public string Render(CultureInfo cultureInfo)
        {
            var jqGridCulture = new StringBuilder();
            jqGridCulture.AppendLine("$.jgrid = $.jgrid || {};");
            jqGridCulture.AppendLine("$.extend($.jgrid,{");
            jqGridCulture.AppendLine("defaults : {");
            jqGridCulture.AppendFormat("recordtext: \"{0}\",\n", Resources.JqGrid.recordtext);
            jqGridCulture.AppendFormat("emptyrecords: \"{0}\",\n", Resources.JqGrid.emptyrecords);
            jqGridCulture.AppendFormat("loadtext: \"{0}\",\n", Resources.JqGrid.loadtext);
            jqGridCulture.AppendFormat("pgtext : \"{0}\"\n", Resources.JqGrid.pgtext);
            jqGridCulture.AppendLine("},");
            jqGridCulture.AppendLine("search : {");
            jqGridCulture.AppendFormat("caption: \"{0}\",\n", Resources.JqGrid.search_caption);
            jqGridCulture.AppendFormat("Find: \"{0}\",\n", Resources.JqGrid.search_Find);
            jqGridCulture.AppendFormat("Reset: \"{0}\",\n", Resources.JqGrid.search_Reset);
            jqGridCulture.AppendFormat("odata: [{{ oper:'eq', text:'{0}'}},{{ oper:'ne', text:'{1}'}},{{ oper:'lt', text:'{2}'}},{{ oper:'le', text:'{3}'}},{{ oper:'gt', text:'{4}'}},{{ oper:'ge', text:'{5}'}},{{ oper:'bw', text:'{6}'}},{{ oper:'bn', text:'{7}'}},{{ oper:'in', text:'{8}'}},{{ oper:'ni', text:'{9}'}},{{ oper:'ew', text:'{10}'}},{{ oper:'en', text:'{11}'}},{{ oper:'cn', text:'{12}'}},{{ oper:'nc', text:'{13}'}}],\n",
                Resources.JqGrid.odata_eq,
                Resources.JqGrid.odata_ne,
                Resources.JqGrid.odata_lt,
                Resources.JqGrid.odata_le,
                Resources.JqGrid.odata_gt,
                Resources.JqGrid.odata_ge,
                Resources.JqGrid.odata_bw,
                Resources.JqGrid.odata_bn,
                Resources.JqGrid.odata_in,
                Resources.JqGrid.odata_ni,
                Resources.JqGrid.odata_ew,
                Resources.JqGrid.odata_en,
                Resources.JqGrid.odata_cn,
                Resources.JqGrid.odata_nc
                );
            jqGridCulture.AppendFormat(
                "groupOps: [	{{ op: \"{0}\", text: \"{1}\" }}, {{ op: \"{2}\",  text: \"{3}\" }}	]\n",
                Resources.JqGrid.groupOps_op_and,
                Resources.JqGrid.groupOps_text_and,
                Resources.JqGrid.groupOps_op_or,
                Resources.JqGrid.groupOps_text_or
                );
            jqGridCulture.AppendLine("},");
            jqGridCulture.AppendLine("edit : {");
            jqGridCulture.AppendFormat("addCaption: \"{0}\",\n", Resources.JqGrid.edit_addCaption);
            jqGridCulture.AppendFormat("editCaption: \"{0}\",\n", Resources.JqGrid.edit_editCaption);
            jqGridCulture.AppendFormat("bSubmit: \"{0}\",\n", Resources.JqGrid.edit_bSubmit);
            jqGridCulture.AppendFormat("bCancel: \"{0}\",\n", Resources.JqGrid.edit_bCancel);
            jqGridCulture.AppendFormat("bClose: \"{0}\",\n", Resources.JqGrid.edit_bClose);
            jqGridCulture.AppendFormat("saveData: \"{0}\",\n", Resources.JqGrid.edit_saveData);
            jqGridCulture.AppendFormat("bYes : \"{0}\",\n", Resources.JqGrid.edit_bYes);
            jqGridCulture.AppendFormat("bNo : \"{0}\",\n", Resources.JqGrid.edit_bNo);
            jqGridCulture.AppendFormat("bExit : \"{0}\",\n", Resources.JqGrid.edit_bExit);
            jqGridCulture.AppendLine("msg: {");
            jqGridCulture.AppendFormat("required: \"{0}\",\n", Resources.JqGrid.msg_required);
            jqGridCulture.AppendFormat("number: \"{0}\",\n", Resources.JqGrid.msg_number);
            jqGridCulture.AppendFormat("minValue: \"{0}\",\n", Resources.JqGrid.msg_minValue);
            jqGridCulture.AppendFormat("maxValue: \"{0}\",\n", Resources.JqGrid.msg_maxValue);
            jqGridCulture.AppendFormat("email: \"{0}\",\n", Resources.JqGrid.msg_email);
            jqGridCulture.AppendFormat("integer: \"{0}\",\n", Resources.JqGrid.msg_integer);
            jqGridCulture.AppendFormat("date: \"{0}\",\n", Resources.JqGrid.msg_date);
            jqGridCulture.AppendFormat("url: \"{0}\",\n", Resources.JqGrid.msg_url);
            jqGridCulture.AppendFormat("nodefined : \"{0}\",\n", Resources.JqGrid.msg_nodefined);
            jqGridCulture.AppendFormat("novalue : \"{0}\",\n", Resources.JqGrid.msg_novalue);
            jqGridCulture.AppendFormat("customarray : \"{0}\",\n", Resources.JqGrid.msg_customarray);
            jqGridCulture.AppendFormat("customfcheck : \"{0}\",\n", Resources.JqGrid.msg_customfcheck);
            jqGridCulture.AppendFormat("			\n");
            jqGridCulture.AppendLine("}");
            jqGridCulture.AppendLine("},");
            jqGridCulture.AppendLine("view : {");
            jqGridCulture.AppendFormat("caption: \"{0}\",\n", Resources.JqGrid.view_caption);
            jqGridCulture.AppendFormat("bClose: \"{0}\",\n", Resources.JqGrid.view_bclose);
            jqGridCulture.AppendLine("},");
            jqGridCulture.AppendLine("del : {");
            jqGridCulture.AppendFormat("caption: \"{0}\",\n", Resources.JqGrid.del_caption);
            jqGridCulture.AppendFormat("msg: \"{0}\",\n", Resources.JqGrid.del_msg);
            jqGridCulture.AppendFormat("bSubmit: \"{0}\",\n", Resources.JqGrid.del_bSubmit);
            jqGridCulture.AppendFormat("bCancel: \"{0}\",\n", Resources.JqGrid.del_bCancel);
            jqGridCulture.AppendLine("},");
            jqGridCulture.AppendLine("nav : {");
            jqGridCulture.AppendFormat("edittext: \"{0}\",\n", Resources.JqGrid.nav_edittext);
            jqGridCulture.AppendFormat("edittitle: \"{0}\",\n", Resources.JqGrid.nav_edittitle);
            jqGridCulture.AppendFormat("addtext: \"{0}\",\n", Resources.JqGrid.nav_addtext);
            jqGridCulture.AppendFormat("addtitle: \"{0}\",\n", Resources.JqGrid.nav_addtitle);
            jqGridCulture.AppendFormat("deltext: \"{0}\",\n", Resources.JqGrid.nav_deltext);
            jqGridCulture.AppendFormat("deltitle: \"{0}\",\n", Resources.JqGrid.nav_deltitle);
            jqGridCulture.AppendFormat("searchtext: \"{0}\",\n", Resources.JqGrid.nav_searchtext);
            jqGridCulture.AppendFormat("searchtitle: \"{0}\",\n", Resources.JqGrid.nav_searchtitle);
            jqGridCulture.AppendFormat("refreshtext: \"{0}\",\n", Resources.JqGrid.nav_refreshtext);
            jqGridCulture.AppendFormat("refreshtitle: \"{0}\",\n", Resources.JqGrid.nav_refreshtitle);
            jqGridCulture.AppendFormat("alertcap: \"{0}\",\n", Resources.JqGrid.nav_alertcap);
            jqGridCulture.AppendFormat("alerttext: \"{0}\",\n", Resources.JqGrid.nav_alerttext);
            jqGridCulture.AppendFormat("viewtext: \"{0}\",\n", Resources.JqGrid.nav_viewtext);
            jqGridCulture.AppendFormat("viewtitle: \"{0}\",\n", Resources.JqGrid.nav_viewtitle);
            jqGridCulture.AppendLine("},");
            jqGridCulture.AppendLine("col : {");
            jqGridCulture.AppendFormat("caption: \"{0}\",\n", Resources.JqGrid.col_caption);
            jqGridCulture.AppendFormat("bSubmit: \"{0}\",\n", Resources.JqGrid.col_bSubmit);
            jqGridCulture.AppendFormat("bCancel: \"{0}\",\n", Resources.JqGrid.col_bCancel);
            jqGridCulture.AppendLine("},");
            jqGridCulture.AppendLine("errors : {");
            jqGridCulture.AppendFormat("errcap : \"{0}\",\n", Resources.JqGrid.errors_errcap);
            jqGridCulture.AppendFormat("nourl : \"{0}\",\n", Resources.JqGrid.errors_nourl);
            jqGridCulture.AppendFormat("norecords: \"{0}\",\n", Resources.JqGrid.errors_norecords);
            jqGridCulture.AppendFormat("model : \"{0}\",\n", Resources.JqGrid.errors_model);
            jqGridCulture.AppendLine("},");
            jqGridCulture.AppendLine("formatter : {");
            jqGridCulture.AppendFormat("integer : {{thousandsSeparator: \"{0}\", defaultValue: '{1}'}},\n", cultureInfo.NumberFormat.NumberGroupSeparator, "0");
            jqGridCulture.AppendFormat("number : {{decimalSeparator:\"{0}\", thousandsSeparator: \"{1}\", decimalPlaces: {2}, defaultValue: '{3}'}},\n", cultureInfo.NumberFormat.NumberDecimalSeparator, cultureInfo.NumberFormat.NumberGroupSeparator, cultureInfo.NumberFormat.NumberDecimalDigits, "0" + cultureInfo.NumberFormat.NumberDecimalSeparator + "00");
            jqGridCulture.AppendFormat("currency : {{decimalSeparator:\"{0}\", thousandsSeparator: \"{1}\", decimalPlaces: {2}, prefix: \"{3}\", suffix:\"{4}\", defaultValue: '{5}'}},\n", cultureInfo.NumberFormat.CurrencyDecimalSeparator, cultureInfo.NumberFormat.CurrencyGroupSeparator, cultureInfo.NumberFormat.CurrencyDecimalDigits, cultureInfo.NumberFormat.CurrencySymbol, "", "0" + cultureInfo.NumberFormat.CurrencyDecimalSeparator + "00");
            jqGridCulture.AppendLine("date : {");
            jqGridCulture.AppendLine("dayNames:   [");
            jqGridCulture.AppendFormat("\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\",\n",
                    cultureInfo.DateTimeFormat.AbbreviatedDayNames[(int)DayOfWeek.Sunday],
                    cultureInfo.DateTimeFormat.AbbreviatedDayNames[(int)DayOfWeek.Monday],
                    cultureInfo.DateTimeFormat.AbbreviatedDayNames[(int)DayOfWeek.Tuesday],
                    cultureInfo.DateTimeFormat.AbbreviatedDayNames[(int)DayOfWeek.Wednesday],
                    cultureInfo.DateTimeFormat.AbbreviatedDayNames[(int)DayOfWeek.Thursday],
                    cultureInfo.DateTimeFormat.AbbreviatedDayNames[(int)DayOfWeek.Friday],
                    cultureInfo.DateTimeFormat.AbbreviatedDayNames[(int)DayOfWeek.Saturday]
                );
            jqGridCulture.AppendFormat("\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\",\n",
                  cultureInfo.DateTimeFormat.DayNames[(int)DayOfWeek.Sunday],
                  cultureInfo.DateTimeFormat.DayNames[(int)DayOfWeek.Monday],
                  cultureInfo.DateTimeFormat.DayNames[(int)DayOfWeek.Tuesday],
                  cultureInfo.DateTimeFormat.DayNames[(int)DayOfWeek.Wednesday],
                  cultureInfo.DateTimeFormat.DayNames[(int)DayOfWeek.Thursday],
                  cultureInfo.DateTimeFormat.DayNames[(int)DayOfWeek.Friday],
                  cultureInfo.DateTimeFormat.DayNames[(int)DayOfWeek.Saturday]
              );
            jqGridCulture.AppendLine("],");
            jqGridCulture.AppendLine("monthNames: [");
            jqGridCulture.AppendFormat("\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\", \"{9}\", \"{10}\", \"{11}\",\n",
                cultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int)MonthOfYear.January - 1],
                cultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int)MonthOfYear.February - 1],
                cultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int)MonthOfYear.March - 1],
                cultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int)MonthOfYear.April - 1],
                cultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int)MonthOfYear.May - 1],
                cultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int)MonthOfYear.June - 1],
                cultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int)MonthOfYear.July - 1],
                cultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int)MonthOfYear.August - 1],
                cultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int)MonthOfYear.September - 1],
                cultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int)MonthOfYear.October - 1],
                cultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int)MonthOfYear.November - 1],
                cultureInfo.DateTimeFormat.AbbreviatedMonthNames[(int)MonthOfYear.December - 1]
                );
            jqGridCulture.AppendFormat("\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\", \"{9}\", \"{10}\", \"{11}\",\n",
                cultureInfo.DateTimeFormat.MonthNames[(int)MonthOfYear.January - 1],
                cultureInfo.DateTimeFormat.MonthNames[(int)MonthOfYear.February - 1],
                cultureInfo.DateTimeFormat.MonthNames[(int)MonthOfYear.March - 1],
                cultureInfo.DateTimeFormat.MonthNames[(int)MonthOfYear.April - 1],
                cultureInfo.DateTimeFormat.MonthNames[(int)MonthOfYear.May - 1],
                cultureInfo.DateTimeFormat.MonthNames[(int)MonthOfYear.June - 1],
                cultureInfo.DateTimeFormat.MonthNames[(int)MonthOfYear.July - 1],
                cultureInfo.DateTimeFormat.MonthNames[(int)MonthOfYear.August - 1],
                cultureInfo.DateTimeFormat.MonthNames[(int)MonthOfYear.September - 1],
                cultureInfo.DateTimeFormat.MonthNames[(int)MonthOfYear.October - 1],
                cultureInfo.DateTimeFormat.MonthNames[(int)MonthOfYear.November - 1],
                cultureInfo.DateTimeFormat.MonthNames[(int)MonthOfYear.December - 1]
                );
            jqGridCulture.AppendLine("],");
            jqGridCulture.AppendFormat("AmPm : [\"{0}\",\"{1}\",\"{2}\",\"{3}\"],\n",
                cultureInfo.TextInfo.ToLower(cultureInfo.DateTimeFormat.AMDesignator),
                cultureInfo.TextInfo.ToLower(cultureInfo.DateTimeFormat.PMDesignator),
                cultureInfo.TextInfo.ToUpper(cultureInfo.DateTimeFormat.AMDesignator),
                cultureInfo.TextInfo.ToUpper(cultureInfo.DateTimeFormat.PMDesignator));
            jqGridCulture.AppendLine("S: function (j) {return j < 11 || j > 13 ? ['st', 'nd', 'rd', 'th'][Math.min((j - 1) % 10, 3)] : 'th';},");
            jqGridCulture.AppendFormat("srcformat: 'Y-m-d',\n  //??");
            jqGridCulture.AppendFormat("newformat: 'n/j/Y',\n  //??");
            jqGridCulture.AppendLine(@"parseRe : /[Tt\\\/:_;.,\t\s-]/,");
            jqGridCulture.AppendLine("masks : {");
            jqGridCulture.AppendFormat("ISO8601Long:\"Y-m-d H:i:s\",\n");
            jqGridCulture.AppendFormat("ISO8601Short:\"Y-m-d\",\n");
            jqGridCulture.AppendFormat("ShortDate: \"{0}\", \n", cultureInfo.DateTimeFormat.ShortDatePattern);
            jqGridCulture.AppendFormat("LongDate: \"{0}\", \n", cultureInfo.DateTimeFormat.LongDatePattern);
            jqGridCulture.AppendFormat("FullDateTime: \"{0}\", \n", cultureInfo.DateTimeFormat.FullDateTimePattern);
            jqGridCulture.AppendFormat("MonthDay: \"{0}\", \n", cultureInfo.DateTimeFormat.MonthDayPattern);
            jqGridCulture.AppendFormat("ShortTime: \"{0}\", \n", cultureInfo.DateTimeFormat.ShortTimePattern);
            jqGridCulture.AppendFormat("LongTime: \"{0}\", \n", cultureInfo.DateTimeFormat.LongTimePattern);
            jqGridCulture.AppendFormat("SortableDateTime: \"{0}\",\n", cultureInfo.DateTimeFormat.SortableDateTimePattern);
            jqGridCulture.AppendFormat("UniversalSortableDateTime: \"{0}\",\n", cultureInfo.DateTimeFormat.UniversalSortableDateTimePattern);
            jqGridCulture.AppendFormat("YearMonth: \"{0}\" \n", cultureInfo.DateTimeFormat.YearMonthPattern);
            jqGridCulture.AppendLine("},");
            jqGridCulture.AppendFormat("reformatAfterEdit : false\n");
            jqGridCulture.AppendLine("},");
            jqGridCulture.AppendFormat("baseLinkUrl: '',\n");
            jqGridCulture.AppendFormat("showAction: '',\n");
            jqGridCulture.AppendFormat("target: '',\n");
            jqGridCulture.AppendFormat("checkbox : {{disabled:true}},\n");
            jqGridCulture.AppendFormat("idName : 'id'\n");
            jqGridCulture.AppendLine("}");
            jqGridCulture.AppendLine("});");

            return jqGridCulture.ToString();
        }
    }
}
