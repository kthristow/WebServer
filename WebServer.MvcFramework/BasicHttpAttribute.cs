using WebServer.HTTP;
using HttpMethod = WebServer.HTTP.HttpMethod;

namespace WebServer.MvcFramework
{
    public abstract class BaseHttpAttribute:Attribute
    {
        public string Url { get; set; }

        public abstract HttpMethod Method { get; }
    }
}
