﻿using WebServer.HTTP;
namespace WebServer.MvcFramework
{
    public abstract class BaseHttpAttribute : Attribute
    {
        public string Url { get; set; }

        public abstract HTTP.HttpMethod Method { get; }
    }
}
