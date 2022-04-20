
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace BattleCards
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // TODO: <Startup>
            await Host.CreateHostAsync(new StartUp(), 80);
        }
    }
}