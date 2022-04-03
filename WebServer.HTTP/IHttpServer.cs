namespace WebServer.HTTP
{
    public interface IHttpServer
    {
         Task StartAsync(int port);

        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action);
    }
}
