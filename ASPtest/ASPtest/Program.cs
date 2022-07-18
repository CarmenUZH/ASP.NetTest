using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdeToFood.Data;
using System;

namespace ASPtest
{
    public class Program
    {
        public static void Main(string[] args)//Like Java, needs to be there
        {
            var host = CreateHostBuilder(args).Build();

            //Step between hosting and running
            MigrateDatabase(host);
                
                host.Run();
        }

        private static void MigrateDatabase(IHost host) //Get the Database
        {
            using(var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<OdeToFoodDbContext>();
                db.Database.Migrate();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

}
