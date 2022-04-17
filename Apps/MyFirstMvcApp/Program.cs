using MyFirstMvcApp.Controllers;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFirstMvcApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new StartUp(), 80);
        }
    }
}