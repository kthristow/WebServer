using BattleCards.Data;
using BattleCards.Services;
using Microsoft.EntityFrameworkCore;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace BattleCards
{
    public class StartUp : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UserService>();
            serviceCollection.Add<ICardsService, CardsService>();
        }

        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}
