using System;
using System.IO;
using Karluks.API.Infrastructure.Data.Repository;
using Karluks.API.Infrastructure.DataProvider;
using Karluks.API.Infrastructure.Interface;
using Karluks.API.Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;

namespace Karluks.API
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
       //     services.AddTransient<IConnection>(_ => new Connection(Configuration["ConnectionStrings:Default"]));
         //   services.AddSingleton<INameRepository, NameRepository>();
         //   services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Karluks Web API", Version = "v1" });
                var filePath = Path.Combine(AppContext.BaseDirectory, "Karluks.API.xml");
                c.IncludeXmlComments(filePath);
            });
            services.AddAuthentication().AddGoogle(
                options => {
                    options.ClientId = "504324819442-rsuo155ieki7gc8eqvrv4iqs5c7u1r2r.apps.googleusercontent.com";
                    options.ClientSecret = "Npar91VyPl9bEzYSDbi9n1Md";    
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                logger.LogInformation("In Development environment");
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
          //  var ser = serviceCollection.AddSingleton<IUserRepository, UserRepository>();
          //  app.KarluksClaimsMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ".Net Core 3 Web API V1");
            });
        }
    }

    /// <summary>
    /// Karluks Claims transformation middleware
    /// </summary>
 //   internal static class KarluksClaimsTransformationMiddleware
 //   {
 //       public static IApplicationBuilder KarluksClaimsMiddleware(this IApplicationBuilder app, IUserRepository userRepository)
 //       {
 //           app.UseMiddleware<KarluksClaims>(userRepository);
 //           return app;
 //       }
 //   }
}
