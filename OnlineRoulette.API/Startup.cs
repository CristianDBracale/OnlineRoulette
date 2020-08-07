using EasyCaching.Core.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineRoulette.DAL.Implementation;
using OnlineRoulette.DAL.Interfaces;
using OnlineRoulette.Gateway.Business;
using OnlineRoulette.Gateway.DataInterfaces;

namespace OnlineRoulette.API
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
            services.AddMemoryCache();
            services.AddStackExchangeRedisCache(setupAction =>
            {
                setupAction.Configuration = Configuration.GetValue<string>("RedisConnection");
                setupAction.InstanceName = Configuration.GetValue<string>("InstanceName");
            });

            services.AddEasyCaching(options =>
            {
                //use redis cache
                options.UseRedis(redisConfig =>
                {
                    //Setup connection
                    redisConfig.DBConfig.Endpoints.Add(new ServerEndPoint(host: Configuration.GetValue<string>("RedisConnectionHost"), port: Configuration.GetValue<int>("RedisConnectionPort")));
                    redisConfig.DBConfig.AllowAdmin = true;
                }, "roulette");
            });

            services.AddScoped<IRouletteBusiness, RouletteBusiness>();
            services.AddScoped<IPlayerBusiness, PlayerBusiness>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRepositoryRoulette, RepositoryRoulette>();
            services.AddScoped<IRepositoryPlayer, RepositoryPlayer>();
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseOpenApi();
            app.UseSwaggerUi3();
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
