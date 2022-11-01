using Azure.Identity;
using Diiage.Directory.Core.Interfaces;
using Diiage.Directory.Core.Interfaces.Services;
using Diiage.Directory.Core.Interfaces.UseCases;
using Diiage.Directory.Core.Models.Configuration;
using Diiage.Directory.Core.UseCases;
using Diiage.Directory.Infrastructure.Database;
using Diiage.Directory.Infrastructure.Mailing;
using Diiage.Directory.Infrastructure.Mapping;
using Diiage.Directory.Infrastructure.Repositories;
using Diiage.Directory.Web.Infrastructure;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

namespace Diiage.Directory.Web
{

    /// <summary>
    /// Application startup.
    /// </summary>
    public class Startup
    {
        private const string _applicationConfigurationSectionName = "ApplicationConfiguration";
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the application configuration.
        /// </summary>
        /// <value>
        /// The application configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the application services.
        /// </summary>
        /// <param name="services">The application services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure configuration services
            services.Configure<ApplicationConfiguration>(Configuration.GetSection(_applicationConfigurationSectionName));
            services.AddScoped(sp => sp.GetService<IOptionsSnapshot<ApplicationConfiguration>>().Value);

            // Bind configuration (for services configuration only)
            var applicationConfiguration = Configuration.GetSection(_applicationConfigurationSectionName).Get<ApplicationConfiguration>();

            // Configure UI configuration service
            services.AddScoped<IGetRemoteUiConfigurationUseCase, GetRemoteUiConfigurationUseCase>();   


            services.AddDbContext<AppDbContext>(options => options

                .UseSqlServer(Configuration["stringdb"]));


            // Congigure Mapping
            services.AddSingleton<IBusinessMapper, Mapper>();

            // Configure business services
            services.AddScoped<IGetEmployeesUseCase, GetEmployeesUseCase>();
            services.AddScoped<IGetEmployeeUseCase, GetEmployeeUseCase>();
            services.AddScoped<ISendEmployeeSummaryUseCase, SendEmployeeSummaryUseCase>();

            // Configure infrastructure services
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration, "AzureAd");

            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ui/dist";
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", p => p.WithOrigins("https://projet4grp1.azurewebsites.net").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddSwaggerGen();
        }

        /// <summary>
        /// Configures the application middlewares.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The hosting environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>()
                .UseStaticFiles();


            //if (!env.IsDevelopment())
            //{
            //    app.UseSpaStaticFiles();
            //}

            app.UseRouting()
                .UseCors("CorsPolicy")
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ui";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("https://projet4grp1.azurewebsites.net");
                }
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
