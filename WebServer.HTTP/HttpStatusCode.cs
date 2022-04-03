namespace WebServer.HTTP
{
    public enum HttpStatusCode
    {
        Ok=200,
        MovedPernamently=301,
        Found=302,
        TemporaryRedirect=307,
        NotFound=404,
        ServerError=500,
    }
}
