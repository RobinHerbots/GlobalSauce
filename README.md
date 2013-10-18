GlobalSauce
===========

Automated culture settings rendering for different javascript plugins.  
Implemented as an htmlhelper extension method (ASP.NET/MVC)

Usage:

In your view or layout add:

```javascript
<script type="text/javascript">
        @Html.GlobalSauce(Components.JqueryGlobalization , Components.JqGrid, Components.JqueryUIDatePicker, Components.JqueryUITimePicker)
</script>
```

This will render the culture settings for the selected components for the CurrentUICulture in .NET

Currently supported plugins:

- jqGrid  
- jquery.globalize  
- jqueryui.datepicker  
- jqueryui.timepicker  

If your language isn't included yet, please do the small effort and make the translation in the resources and commit it back to the project.  
This way everyone can profit from it.
