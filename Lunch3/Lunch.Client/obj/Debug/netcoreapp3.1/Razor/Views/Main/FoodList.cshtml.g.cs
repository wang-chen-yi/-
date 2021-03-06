#pragma checksum "E:\VS Working\.net core\Lunch\Lunch.Client\Views\Main\FoodList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a20e261bee72c58ee43e19c1c7c9d12157222977"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_FoodList), @"mvc.1.0.view", @"/Views/Main/FoodList.cshtml")]
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
#line 1 "E:\VS Working\.net core\Lunch\Lunch.Client\Views\_ViewImports.cshtml"
using Lunch.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\VS Working\.net core\Lunch\Lunch.Client\Views\_ViewImports.cshtml"
using Lunch.Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a20e261bee72c58ee43e19c1c7c9d12157222977", @"/Views/Main/FoodList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e948ff66a9002073c623977dbf22f2275706760", @"/Views/_ViewImports.cshtml")]
    public class Views_Main_FoodList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<template>
    <div class=""goods-list-container"">

        <el-row :gutter=""15"">
            <el-col v-for=""(item, index) in list""
                    :key=""index""
                    :xs=""24""
                    :sm=""8""
                    :md=""8""
                    :lg=""8""
                    :xl=""6"">
                <el-card :body-style=""{ padding: '0px' }"" shadow=""hover"">
                    <div class=""goods-list-card-body"">
                        <div class=""goods-list-tag-group"">
                            <el-tag v-if=""item.isRecommend"" hit type=""success"">推荐</el-tag>
                            <el-tag v-if=""item.status === 0"" hit type=""danger"">缺货</el-tag>
                        </div>
                        <div class=""goods-list-image-group"">
                            <img :src=""item.image"" class=""goods-list-image"" />
                        </div>
                        <div class=""goods-list-title"">{{ item.title }}</div>
                        <div class=""goods-list-d");
            WriteLiteral(@"escription"">{{ item.description }}</div>
                        <div class=""goods-list-price"">
                            <span>¥ {{ item.price }} 元</span>
                        </div>
                    </div>
                </el-card>
            </el-col>
        </el-row>
        <el-pagination background
                       :current-page=""queryForm.pageNo""
                       :layout=""layout""
                       :page-size=""queryForm.pageSize""
                       :total=""total""
                       ");
            WriteLiteral("@current -change=\"handleCurrentChange\"\r\n                       ");
            WriteLiteral("@ize -change=\"handleSizeChange\"></el-pagination>\r\n    </div>\r\n</template>\r\n\r\n");
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
