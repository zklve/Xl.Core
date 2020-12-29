using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xl.Core.API.Modules;
using Xl.Core.UniversalCommon;

namespace Xl.Core.API
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
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            #region 配置注入
            var config = new ConfigurationBuilder();
            config.AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/Configs/Autofac", "Common.json"));
            var module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);

            config.AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/Configs/Autofac", "Repository.json"));
            module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);

            config.AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/Configs/Autofac", "Service.json"));
            module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);

            #endregion

            #region 全局对象注册
            builder.RegisterBuildCallback(scope =>
            {
                Application.Container = (IContainer)scope;
            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
