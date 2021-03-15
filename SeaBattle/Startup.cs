using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeaBattle.Data;
using SeaBattle.Helpers;
using SeaBattle.Models;
using SeaBattle.Services;

namespace SeaBattle
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddSingleton<Game>();
            services.AddSingleton<BattleStatistics>();

            services.AddScoped<ICreationService, CreationService>();
            services.AddScoped<ICoordinatesParser, CoordinatesParser>();
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<IBattleService, BattleService>();
            services.AddScoped<IGameLifetimeService, GameLifetimeService>();
            services.AddScoped<INeighboringCellsMarker, NeighboringCellsMarker>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SeaBattle API");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
