﻿using BattleCards.Data;
using Microsoft.EntityFrameworkCore;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace BattleCards
{
    public class StartUp : IMvcApplication
    {
        public void ConfigureServices()
        {
        }

        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}
