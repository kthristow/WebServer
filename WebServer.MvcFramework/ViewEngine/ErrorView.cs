﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.MvcFramework.ViewEngine
{
    public class ErrorView : IView
    {
        private readonly IEnumerable<string> errors;
        private readonly string csharpCode;

        public ErrorView(IEnumerable<string> errors, string csharpCode)
        {
            this.errors = errors;
            this.csharpCode = csharpCode;
        }

        public string ExecuteTemplate(object viewModel)
        {
            var html = new StringBuilder();
            html.AppendLine($"<h1>View compile {this.errors.Count()} errors:</h1><ul>");
            foreach (var error in this.errors)
            {
                html.AppendLine($"<li>{error}</li>");
            }

            html.AppendLine($"</ul><pre>{csharpCode}</pre>");
            return html.ToString();
        }
    }
}
