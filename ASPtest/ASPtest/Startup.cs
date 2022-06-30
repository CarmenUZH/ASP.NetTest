using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdeToFood.Data;
using System;

namespace ASPtest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //"Tell me about all the components you need"
        {
            services.AddDbContextPool<OdeToFoodDbContext>(options =>
            {
              options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDb"));
            });

            //  services.AddSingleton<IRestaurantData, InMemoryRestaurantData>(); //The "database"
            services.AddScoped<IRestaurantData, SqlRestaurantData>(); //The real Database
            services.AddRazorPages();
            services.AddControllers();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //Remember the Middleware pipeline! Cares about outgoing respone
            }
            else
            {
                app.UseExceptionHandler("/Error"); //Userfriendly Error handler 
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(SayHelloToMichael); //No matter what i do, this gets called first and nothing happens
            app.UseHttpsRedirection();
            app.UseStaticFiles(); //Middleware component
            app.UseNodeModules(); //He has "env" inside the brackets
            app.UseRouting();
            //He uses something that doesnt work for me (see useEndpoints)

            app.UseAuthorization();//For finding out who the user is (anything after this KNOWS who we're dealing with)

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

        private RequestDelegate SayHelloToMichael(RequestDelegate arg) //a request delicate is a method that takes an http context and returns a task
        {
            return async ctx => //Lamda expression
            {
                if (ctx.Request.Path.StartsWithSegments("/hello")) //ONLY show when link starts with /hello
                {
                    await ctx.Response.WriteAsync("Hello, Michael.");
                }
                else
                {
                    await arg(ctx); //send message along to next thing (loads page as usual)
                }
            };
        }
    }
}
