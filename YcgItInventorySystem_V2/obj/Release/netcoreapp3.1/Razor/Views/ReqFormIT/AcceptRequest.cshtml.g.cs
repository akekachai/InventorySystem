#pragma checksum "C:\Users\akekachai.jar\source\repos\YcgItInventorySystem_V2\YcgItInventorySystem_V2\Views\ReqFormIT\AcceptRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b3a71883d6de944cc99f2673929b96cdf9f696ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ReqFormIT_AcceptRequest), @"mvc.1.0.view", @"/Views/ReqFormIT/AcceptRequest.cshtml")]
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
#line 1 "C:\Users\akekachai.jar\source\repos\YcgItInventorySystem_V2\YcgItInventorySystem_V2\Views\_ViewImports.cshtml"
using YcgItInventorySystem_V2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\akekachai.jar\source\repos\YcgItInventorySystem_V2\YcgItInventorySystem_V2\Views\_ViewImports.cshtml"
using YcgItInventorySystem_V2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3a71883d6de944cc99f2673929b96cdf9f696ae", @"/Views/ReqFormIT/AcceptRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7690dd69da40324f977c41b9a3040e775e751d43", @"/Views/_ViewImports.cshtml")]
    public class Views_ReqFormIT_AcceptRequest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<YcgItInventorySystem_V2.Models.Inventory.SP_ReqFormItList>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-pageid", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\akekachai.jar\source\repos\YcgItInventorySystem_V2\YcgItInventorySystem_V2\Views\ReqFormIT\AcceptRequest.cshtml"
  
    ViewData["Title"] = "AcceptRequest";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h4>รับเรื่องการขอใช้บริการ</h4>

<div class=""alert alert-success alert-dismissible"" id=""NewMsg"" style=""display: none;"">

</div>
<table class=""table"">
    <thead>
        <tr>
            <th>
                เลขที่รายการ
            </th>
            <th>
                ชื่อผู้ใช้บริการ
            </th>
            <th>
                ฝ่าย/แผนก
            </th>

            <th></th>
        </tr>
    </thead>
    <tbody>

");
#nullable restore
#line 31 "C:\Users\akekachai.jar\source\repos\YcgItInventorySystem_V2\YcgItInventorySystem_V2\Views\ReqFormIT\AcceptRequest.cshtml"
         foreach (var item in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 36 "C:\Users\akekachai.jar\source\repos\YcgItInventorySystem_V2\YcgItInventorySystem_V2\Views\ReqFormIT\AcceptRequest.cshtml"
               Write(Html.DisplayFor(modelItem => item.ReqNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 39 "C:\Users\akekachai.jar\source\repos\YcgItInventorySystem_V2\YcgItInventorySystem_V2\Views\ReqFormIT\AcceptRequest.cshtml"
               Write(Html.DisplayFor(modelItem => item.UsersName_TH));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 42 "C:\Users\akekachai.jar\source\repos\YcgItInventorySystem_V2\YcgItInventorySystem_V2\Views\ReqFormIT\AcceptRequest.cshtml"
               Write(Html.DisplayFor(modelItem => item.DepartmentText));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 45 "C:\Users\akekachai.jar\source\repos\YcgItInventorySystem_V2\YcgItInventorySystem_V2\Views\ReqFormIT\AcceptRequest.cshtml"
                       if (item.ReqStatus == "1-2")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3a71883d6de944cc99f2673929b96cdf9f696ae7021", async() => {
                WriteLiteral("ดูรายละเอียดขอใช้บริการ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "C:\Users\akekachai.jar\source\repos\YcgItInventorySystem_V2\YcgItInventorySystem_V2\Views\ReqFormIT\AcceptRequest.cshtml"
                                                   WriteLiteral(item.ReqNo);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageid"] = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\Users\akekachai.jar\source\repos\YcgItInventorySystem_V2\YcgItInventorySystem_V2\Views\ReqFormIT\AcceptRequest.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 54 "C:\Users\akekachai.jar\source\repos\YcgItInventorySystem_V2\YcgItInventorySystem_V2\Views\ReqFormIT\AcceptRequest.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3a71883d6de944cc99f2673929b96cdf9f696ae10361", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>

    $(document).ready(function () {
        //var queryStringCollection = Request.Query;
        //console.log(queryStringCollection);

        //var queryString = HttpContext.Request.QueryString;
        //console.log(queryString);
        var ReqNo = """";
        try
        {

            ReqNo =  """);
#nullable restore
#line 70 "C:\Users\akekachai.jar\source\repos\YcgItInventorySystem_V2\YcgItInventorySystem_V2\Views\ReqFormIT\AcceptRequest.cshtml"
                 Write(Context.Request.Query["ReqNo"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""

        }
        catch { }


        /*ReqNo = System.Web.HttpContext.Current.Request.QueryString[""ReqNo""];*/
        //

        console.log(ReqNo);
        if (ReqNo == """") {
            $('#NewMsg').hide();
        }
        else {
            var x = document.getElementById(""NewMsg"");
            if (x.style.display === ""none"") {
                x.style.display = ""block"";
            } else {
                x.style.display = ""none"";
            }

            $('#NewMsg').html('<a href=# class=close data-dismiss=alert aria-label=close>&times;</a> รับเรื่องขอใช้บริการสำเร็จรายการเลขที่ : ' + ReqNo );
        }


    });
</script> ");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<YcgItInventorySystem_V2.Models.Inventory.SP_ReqFormItList>> Html { get; private set; }
    }
}
#pragma warning restore 1591
