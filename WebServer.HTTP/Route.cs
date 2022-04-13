namespace WebServer.HTTP
{
    public class Route
    {
        public Route(string path, HttpMethod method,Func<HttpRequest, HttpResponse> action)
        {
            this.Path = path;
            Action = action;
            Method = method;

        }
        public string Path { get; set; }

        public HttpMethod Method { get; set; }
        public Func<HttpRequest,HttpResponse> Action { get; set; }
    }
}
