#pragma checksum "D:\Projects\TestAssignments\Synel\TestAssignmentSynell\mvcclient\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7202e9d35e19ac7146753e777f185980296f898"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\Projects\TestAssignments\Synel\TestAssignmentSynell\mvcclient\Views\_ViewImports.cshtml"
using mvcclient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\TestAssignments\Synel\TestAssignmentSynell\mvcclient\Views\_ViewImports.cshtml"
using mvcclient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7202e9d35e19ac7146753e777f185980296f898", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a84b76dd5260bb418b85ae0b48fda7643ce47a0d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Projects\TestAssignments\Synel\TestAssignmentSynell\mvcclient\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    p, li {
        font-size: 1.1em;
    }
</style>

<div class=""jumbotron py-4"">
    <h1>Application Summary</h1>
</div>
<div class=""row"">
    <div class=""col-md-6"">
        <h2>API Architecture</h2>
        <p>Net Core 3.0</p>
        <p>Client server approach is used. Calls to API are made with HttpClient in MVC Application. DB access is made
            with EF ORM. SqlLite db is used.</p>
        <section><h4>Architectural Patterns:</h4>
            <ul>
                <li>Clean(Ontion) Architecture => <strong>Infrastructure</strong> contains DB access logic and servces (file service in
                    this app). <strong>Core</strong> contains interfaces, data entities</li>
                <li>Generic repository pattern is implemented</li>
                <li>Specification pattern enables proper use of Generic Repository. This way we can apply filtering, sorting, pagination, and include statements (with nested entities) in the specification object and pass the object to ");
            WriteLiteral(@"generic repo methods </li>
                <li>UnitOfWork pattern used to instantiate db only once for all repos and provide facade to all repos</li>
            </ul>

        </section>
        <section>
            <h4>Design patterns attempted (file upload):</h4>
            <ul>
                <li>When saving file to API, <strong>Facade</strong> provides abstraction from logic</li>
                <li><strong>Template method</strong> pattern is used to enable multiple file extensions other than .csv </li>
                <li><b>Strategy</b> pattern is used to pass different configurations to file formatters</li>
            </ul>
        </section>
        <section>
            <div class=""h4"">Nuget packages (incomplete list):</div>
            <ul>
                <li>AutoMapper to map DTOs to Entities</li>
                <li>CsvHelper</li>
                <li>Json.Newtonsoft</li>
            </ul>
        </section>


    </div>
    <div class=""col-md-6"">
        <h2>To-do</h");
            WriteLiteral(@"2>
     
        <ul>
           
            <li>(Client) Make wrapper around HttpClient logic. Abstract http logic from the controller</li>
            <li>Files represent batches. Records could be displayed for a specific batch vs. being shown all in one table.</li>
            <li>Add records to a batch (file represenation in db)</li>
            <li>(API) When uploading batch, save 100 records or less at a time. If somewhere along the way exception/error occurs, roll back transaction. With files containing massive number of records, we want to ""feed"" small portions to db at a time</li>
            <li>Unit Tests (learn and implement)</li>
        </ul>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591