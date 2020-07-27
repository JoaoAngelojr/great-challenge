using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using great_challenge.Abstract;
using great_challenge.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace great_challenge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "GreatChallengeReact";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("HOST_IP_ADDRESS"));
            });

            services.AddCors(options =>
                options.AddPolicy(MyAllowSpecificOrigins,
                builder => builder
                    .WithOrigins("HOST_ADDRESS")
                    .AllowAnyOrigin()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithHeaders("Access-Control-Allow-Headers", "accept", "content-type", "origin")));

            services.AddDbContext<greatContext>(options =>
            options.UseSqlServer(@"Server=LOCAL_DESKTOP;Database=DB_NAME;Trusted_Connection=True;"));

            services.AddControllers();

            services.AddTransient(typeof(IGreatRepository<>), typeof(GreatRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
