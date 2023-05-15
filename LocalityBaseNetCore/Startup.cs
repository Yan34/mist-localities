using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalityBaseNetCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NReco.Logging.File;
using static LocalityBaseNetCore.Program;

namespace LocalityBaseNetCore
{
    public class Startup
    {
        // private readonly ILogger<Startup> _logger;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            // using var loggerFactory = LoggerFactory.Create(builder =>
            // {
            //     // builder.SetMinimumLevel(LogLevel.Information);
            //     builder.AddFile("localities_{0:yyyy}-{0:MM}-{0:dd}.log", fileLoggerOpts => {
            //         fileLoggerOpts.FormatLogFileName = fName => {
            //             return String.Format(fName, DateTime.UtcNow);
            //         };
            //         fileLoggerOpts.MinLevel = LogLevel.Information;
            //     });
            //     // builder.AddEventSourceLogger();
            // });
            // _logger = loggerFactory.CreateLogger<Startup>();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder => {
                loggingBuilder
                    .AddFile("localities_{0:yyyy}-{0:MM}-{0:dd}.log", fileLoggerOpts => {
                    fileLoggerOpts.FormatLogFileName = fName => {
                        return String.Format(fName, DateTime.UtcNow);
                    };
                    fileLoggerOpts.MinLevel = LogLevel.Information;
                });
                
            });
            // string connection = Configuration.GetConnectionString("DefaultConnection");
            // services.AddDbContext<LocalitiesContext>(options => options.UseSqlServer(connection));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseExceptionHandler("/Home/Error");
                // // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
                app.UseExceptionHandler(a => a.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = exceptionHandlerPathFeature.Error;

                    // logging
                    // _logger.Log(LogLevel.Error, exception.Message);

                    // exception page
                    var result = JsonConvert.SerializeObject(new { error = exception.Message });
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(result);
                }));
                app.UseHsts();
            }
            
            app.UseStatusCodePages();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}