using Green.Darts.Dao.EntityFrameworkCore;
using Green.Darts.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Green.Darts
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=GreenDartsDatabase;Trusted_Connection=True;";
            services.AddDbContext<DartsDbContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IGameRepository>(c => new EntityFrameworkCoreGameRepository(c.GetService<DartsDbContext>()));
            services.AddTransient<IPlayerRepository>(c => new EntityFrameworkCorePlayerRepository(c.GetService<DartsDbContext>()));
            services.AddMvc();
            services.AddSignalR(options =>
            {
                options.Hubs.EnableDetailedErrors = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod().AllowCredentials());
            app.UseMvc();
            app.UseFileServer();
            app.UseWebSockets();
            app.UseSignalR();
        }
    }
}
