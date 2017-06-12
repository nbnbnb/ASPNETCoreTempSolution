using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;  // Extensions
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace BasicSite
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            // Add framework services.
            services
                .AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)  // 只有添加了这个服务后，在能在 Controller 中注入 IHtmlLocalizer<T>
                .AddDataAnnotationsLocalization();

            // Add EF Core Libs
            // Microsoft.EntityFrameworkCore.SqlServer
            // Microsoft.EntityFrameworkCore.Tools
            // using Microsoft.EntityFrameworkCore;

            // 配置连接字符串在 appsettings.json 中
            services.AddDbContext<Data.ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            var supportedCultures = new[]
                {
                    new CultureInfo("zh-CN"),
                    new CultureInfo("zh-TW"),
                    new CultureInfo("zh"),
                    new CultureInfo("en-US"),
                    new CultureInfo("en-AU"),
                    new CultureInfo("en-GB"),
                    new CultureInfo("en"),
                    new CultureInfo("es-ES"),
                    new CultureInfo("es-MX"),
                    new CultureInfo("es"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("fr"),
                };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("zh-CN"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            app.UseStaticFiles();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
