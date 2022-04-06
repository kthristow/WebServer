namespace WebServer.HTTP
{
    public class Route
    {
        public Route(string path, Func<HttpRequest, HttpResponse> action)
        {
            this.Path = path;
            Action = action;
        }
        public string Path { get; set; }

        public Func<HttpRequest,HttpResponse> Action { get; set; }
    }
}
