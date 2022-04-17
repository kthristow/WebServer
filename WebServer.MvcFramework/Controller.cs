﻿using System.Runtime.CompilerServices;
using System.Text;
using WebServer.HTTP;
using WebServer.MvcFramework.ViewEngine;

namespace WebServer.MvcFramework
{
    public abstract class Controller
    {
        private SusViewEngine viewEngine;

       
        public Controller()
        {
            this.viewEngine = new SusViewEngine();
        }
         public HttpRequest Request { get; set; }
        public HttpResponse View(object viewModel=null,[CallerMemberName]string viewPath=null)
        {
            var layout = System.IO.File
                .ReadAllText("Views/Shared/_Layout.cshtml");
            layout = layout.Replace("@RenderBody()", "____VIEW_GOES_HERE____");
            layout = this.viewEngine.GetHtml(layout, viewModel);

            var viewContent =
                System.IO.File
                .ReadAllText("Views/"+this.GetType().Name.Replace("Controller",string.Empty)+"/"+viewPath+".cshtml");
            viewContent = this.viewEngine.GetHtml(viewContent, viewModel);

            var responseHtml = layout.Replace("____VIEW_GOES_HERE____", viewContent);
            var responseBody = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBody);
            return response;
        }

        public HttpResponse File(string filePath,string contentType)
        {

            var fileBtyes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileBtyes);
            return response;
        }

        public HttpResponse Redirect(string url)
        {
            var response = new HttpResponse(HttpStatusCode.Found);
            response.Headers.Add(new Header("Location", url));
            return response;
        }
    }
}
