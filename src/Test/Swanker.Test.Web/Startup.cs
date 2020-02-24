using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Acnys.Core.AspNet;
using Acnys.Core.AspNet.Request;
using Acnys.Core.Request.Abstractions;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swanker.Test.Api.Queries;

namespace Swanker.Test.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(Assembly.GetEntryAssembly()).AddControllersAsServices();
            services.AddControllers().AddApplicationPart(typeof(SwankGenericController).Assembly).AddControllersAsServices();
            services.AddSwank(c =>
            {
                c.GenericEndpoint = "/api";
                c.Assembly = typeof(MyQuery).Assembly;
                c.Types = new List<Type> { typeof(IQuery<>), typeof(ICommand) };
                c.AppName = "Test Web App";
                c.AppVersion = "1.0.0";
                c.AllowSendToGeneric = true;
            });

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();


            app.AddReadiness();
            app.AddLiveness();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHttpRequestHandler("api");
                endpoints.MapSwankController("swanker");
                endpoints.MapControllers();
            });
        }
    }
}
