#pragma checksum "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "479330f15c0d34de9c5ff7fa1623deb1beeeaf72"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Appointments_Edit), @"mvc.1.0.view", @"/Views/Appointments/Edit.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\_ViewImports.cshtml"
using HospitalScheduler.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\_ViewImports.cshtml"
using HospitalScheduler.WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\_ViewImports.cshtml"
using HospitalScheduler.Entities.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"479330f15c0d34de9c5ff7fa1623deb1beeeaf72", @"/Views/Appointments/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b1127baa9baa24ab6401c5889bf255c37495d29", @"/Views/_ViewImports.cshtml")]
    public class Views_Appointments_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AppointmentVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/js/EditAppointment.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
  
    ViewData["Title"] = "Edit Appointment";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <div class=\"container\" id=\"IdContainer\" data-id=");
#nullable restore
#line 8 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
                                               Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(">\r\n        <div class=\"data-wrapper\">\r\n            <h3 class=\"display-4\">\r\n                Patient: ");
#nullable restore
#line 11 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
                    Write(Model.Patient);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h3>\r\n            <h3 class=\"display-4\">\r\n                Date: ");
#nullable restore
#line 14 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
                 Write(Model.AppointmentDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h3>\r\n            <h3 class=\"display-4\">\r\n                Room: ");
#nullable restore
#line 17 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
                 Write(Model.Room);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h3>\r\n");
#nullable restore
#line 19 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
             if (Model.TypeId == (int)AppointmentTypes.Consultation)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h3 class=\"display-4\">\r\n                    Type: Consultation\r\n                </h3>\r\n");
#nullable restore
#line 24 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h3 class=\"display-4\">\r\n                    Type: Intervention\r\n                </h3>\r\n");
#nullable restore
#line 30 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
             if (Model.StatusId == (int)AppointmentStatus.Pending)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h3 class=\"display-4\">\r\n                    Status: Pending\r\n                </h3>\r\n");
#nullable restore
#line 36 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
            }
            else if (Model.StatusId == (int)AppointmentStatus.Confirmed)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h3 class=\"display-4\">\r\n                    Status: Confirmed\r\n                </h3>\r\n");
#nullable restore
#line 42 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h3 class=\"display-4\">\r\n                    Status: Finished\r\n                </h3>\r\n");
#nullable restore
#line 48 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h3 class=\"display-4\">\r\n                Duration: ");
#nullable restore
#line 50 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
                     Write(Model.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral(" minutes\r\n            </h3>\r\n            <h3 class=\"display-4\">\r\n                Details: ");
#nullable restore
#line 53 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
                    Write(Model.Details);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h3>\r\n            <h3 class=\"display-4\">\r\n                Conclusions: ");
#nullable restore
#line 56 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
                        Write(Model.Conclusions);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h3>\r\n        </div>\r\n        <div class=\"input-wrapper\">\r\n");
#nullable restore
#line 60 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
             if (Model.StatusId == (int)AppointmentStatus.Pending)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div>
                    <h4>This appointment has not been yet confirmed</h4>
                    <button type=""button"" id=""confirmBtn"" class=""btn btn-primary"">Confirm</button>
                    <button type=""button"" id=""denyBtn"" class=""btn btn-primary"">Deny</button>
                </div>
");
#nullable restore
#line 67 "D:\Users\user\source\repos\HospitalScheduler\HospitalScheduler.WebApp\Views\Appointments\Edit.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "479330f15c0d34de9c5ff7fa1623deb1beeeaf729888", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public HospitalScheduler.Entities.DTOs.CurrentUserDto CurrentUser { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AppointmentVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
