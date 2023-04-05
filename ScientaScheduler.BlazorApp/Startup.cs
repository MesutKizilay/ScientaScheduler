using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScientaScheduler.BlazorApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Blazor;

namespace ScientaScheduler.BlazorApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddSyncfusionBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense
               ("Mgo+DSMBaFt+QHFqVkFrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRcQl5gSX5Rck1jWXhbdHQ=;Mgo+DSMBPh8sVXJ1S0d+X1ZPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSX1QdkVhXXdecHNTQGA=;ORg4AjUWIQA/Gnt2VFhhQlJDfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5QdUVjW3tWcHRSQWlc;MTU1MzA5NEAzMjMxMmUzMTJlMzMzN0pxN0RJdHo0ZnFRMnBjZnczOExPM2R5TVRjUkxJcHBqQllGb2VJRWwwalE9;MTU1MzA5NUAzMjMxMmUzMTJlMzMzN0FBelpnSmg3Y3BDOG9zZ21SNGdHVVc5ZXNUSEE0cURCNVlyK0JlbXpEOUk9;NRAiBiAaIQQuGjN/V0d+XU9HcVRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TdUZjWX1aeHRVTmRfUQ==;MTU1MzA5N0AzMjMxMmUzMTJlMzMzN2J5ekZQZFVJandZN1hJOUJPUGNwbTd6a3FhOGNMeTdxREpNZXJXd2oySjg9;MTU1MzA5OEAzMjMxMmUzMTJlMzMzN002SnFXdnNZNzZEZFdSeUVFQ0NpUFpvQ09ocDJmbjAzRVYyWkFxMDBqOE09;Mgo+DSMBMAY9C3t2VFhhQlJDfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5QdUVjW3tWcHRcRmdc;MTU1MzEwMEAzMjMxMmUzMTJlMzMzN0kyWmlsUi85MEROWTgrc01zY2s3eHFVaHZOdFVZVU1ZOXpnN1lEVW1oMkU9;MTU1MzEwMUAzMjMxMmUzMTJlMzMzN0IxVVcvdlBldHJTUCt4U0pMR0ZkRmdNTUN3blpITm9mNFNxeksvS2hUVTA9;MTU1MzEwMkAzMjMxMmUzMTJlMzMzN2J5ekZQZFVJandZN1hJOUJPUGNwbTd6a3FhOGNMeTdxREpNZXJXd2oySjg9");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
