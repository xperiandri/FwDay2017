namespace Microsoft.Examples
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Mvc.Versioning;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.PlatformAbstractions;
    using Swashbuckle.AspNetCore.Swagger;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
            services.AddApiVersioning(o => o.ReportApiVersions = true);

            services.AddSwaggerGen(c =>
            {
                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    var model = apiDesc.ActionDescriptor.GetProperty<ApiVersionModel>();
                    switch (model)
                    {
                        case ApiVersionModel _ when model.IsApiVersionNeutral: return true;
                        case ApiVersionModel _ when model.DeclaredApiVersions.Any():
                            return model.DeclaredApiVersions
                                        .Any(apiVersion => apiVersion.ToString() == docName);
                        case ApiVersionModel _ when model.ImplementedApiVersions.Any():
                            return model.ImplementedApiVersions
                                        .Any(apiVersion => apiVersion.ToString() == docName);
                        default: return false;
                    }
                });


                c.SwaggerDoc("1.0",
                    new Info
                    {
                        Version = "1.0",
                        Title = "Swashbuckle Sample API",
                        Description = "A sample API for testing Swashbuckle",
                        TermsOfService = "Some terms ..."
                    }
                );
                c.SwaggerDoc("2.0",
                    new Info
                    {
                        Version = "2.0",
                        Title = "Swashbuckle Sample API",
                        Description = "A sample API for testing Swashbuckle",
                        TermsOfService = "Some terms ..."
                    }
                );

                c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Demo3.xml"));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseDeveloperExceptionPage();
            app.UseMvc();
            app.UseApiVersioning();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/1.0/swagger.json", "V1 Docs");
                c.SwaggerEndpoint("/swagger/2.0/swagger.json", "V2 Docs");
            });
        }
    }
}
