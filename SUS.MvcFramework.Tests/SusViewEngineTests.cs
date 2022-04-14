using System;
using System.Collections.Generic;
using System.IO;
using WebServer.MvcFramework.ViewEngine;
using Xunit;

namespace WebServer.MvcFramework.Tests
{
    public class SusViewEngineTests
    {
        [Theory]
        [InlineData("CleanHtml")]
        [InlineData("Foreach")]
        [InlineData("IfElseFor")]
        [InlineData("ViewModel")]
        public void TestGetHtml(string fileName)
        {
            var viewModel = new TestViewModel()
            {
                DateOfBirth = new DateTime(2019, 6, 1),
                Name = "Doggo Arghentino",
                Price = 12345.67M
            };
            IViewEngine viewEngine = new SusViewEngine();
            string view = File.ReadAllText($"ViewTests/{fileName}.html");
            string result = viewEngine.GetHtml(view, viewModel);
            string expectedResult = File.ReadAllText($"ViewTests/{fileName}.Result.html");
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void TestTemplateViewModel()
        {
            IViewEngine viewEngine=new SusViewEngine();
           var actual= viewEngine.GetHtml(@"@foreach(var num in Model)
{
<span>@num</span>
}", new List<int> { 1, 2, 3 });
            var expected = 
@"<span>1</span>
<span>2</span>
<span>3</span>
"
;
            Assert.Equal(expected, actual);
        }
    }
}