# GlobalSauce

Automated culture settings rendering for different javascript plugins.  
Implemented as an htmlhelper extension method (ASP.NET/MVC)

Usage:

In your view or layout add:

```html
<script type="text/javascript">
        @Html.GlobalSauce(Components.JqueryGlobalization , Components.JqGrid, Components.JqueryUIDatePicker)
</script>
```

or when using with the GlobalsauceController

add to the web.config

```
<location path="Globalsauce">
    <system.web>
      <authorization>
        <allow users="*" />
      </authorization>
    </system.web>
</location>
```
make a request like http://<host>/Globalsauce/Get/jqGrid


This will render the culture settings for the selected components for the CurrentUICulture in .NET

Currently supported plugins:

- jqGrid  
- jquery.globalize  
- jqueryui.datepicker  
- jqueryui.timepicker  
- ckeditor

If your language isn't included yet, please do the small effort and make the translation in the resources and commit it back to the project.  
This way everyone can profit from it.

### ckeditor

```html
<script type="text/javascript">
        @Html.GlobalSauce(Components.ckeditor)
		
		$(".ckeeditor").ckeditor({ language: '@Thread.CurrentThread.CurrentUICulture.Name' });
</script>
```
