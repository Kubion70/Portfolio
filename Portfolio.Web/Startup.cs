using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Portfolio.Data.Configurations;
using Portfolio.Database;
using Portfolio.IOC;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Portfolio.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Client App Configuration
            var clientAppConfiguration = new ClientAppConfiguration();
            Configuration.Bind("ClientApp", clientAppConfiguration);
            services.AddSingleton(clientAppConfiguration);

            // Translations Configuration
            var translationsConfiguration = new TranslationsConfiguration();
            Configuration.Bind("Translations", translationsConfiguration);
            services.AddSingleton(translationsConfiguration);

            var smtpConfiguration = new SmtpConfiguration();
            Configuration.Bind("Smtp", smtpConfiguration);
            services.AddSingleton(smtpConfiguration);

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Cors config
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(clientAppConfiguration.RedirectUrl)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Portfolio API", Version = "v1" });
            });

            return Handler.Configure(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            // Database upgrade
            var dbUpgrader = new DbUpgrader(Configuration["ConnectionString"]);
            if (env.IsDevelopment())
            {
                dbUpgrader.Upgrade(withFakes: true);
            }
            else
            {
                dbUpgrader.Upgrade();
            }

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portfolio API");
                    c.RoutePrefix = "api";
                });
            }

            app.UseRequestLocalization();

            app.UseMvcWithDefaultRoute();
        }
    }
}