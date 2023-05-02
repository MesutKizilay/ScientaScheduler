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
using ScientaScheduler.BlazorApp.Services.Interface;
using ScientaScheduler.BlazorApp.Services.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Blazored.LocalStorage;

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
            services.AddHttpClient();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor();
           
            services.AddBlazoredLocalStorage();

            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<IProjectService, ProjectManager>();
            services.AddSingleton<ITaskService, TaskManager>();
            services.AddSingleton<IAuthService, AuthManager>();
            services.AddSingleton<IResourceService, ResourceManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense
               ("Mgo + DSMBaFt / QHFqVVhmXVpFdEBBXHxAd1p / VWJYdVt5flBPcDwsT3RfQF5jTX5WdkFmWn9dcn1URA ==; Mgo + DSMBPh8sVXJ0S0d + XE9Cd1RDX3xKf0x / TGpQb19xflBPallYVBYiSV9jS31TckVmWXtbc3RWRWVZUw ==; ORg4AjUWIQA / Gnt2VVhhQlFacF5JXGFWfVJpTGpQdk5xdV9DaVZUTWY / P1ZhSXxQdkFjXH9adXdVRWNbUEY =; MTYyNDY3NkAzMjMwMmUzMTJlMzBBeDRrVC9CeUN1dzd1Rm8xM1hGWU40UGR4WU80c2lac3RTc0VoWnNSWGV3PQ ==; MTYyNDY3N0AzMjMwMmUzMTJlMzBaUVlOZDlsV0dRTlFkVkhYWUhQa2tMQ0FNeXpIZnN6Y1JrSFFkWEtMd3lvPQ ==; NRAiBiAaIQQuGjN / V0Z + XU9EaFlDVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdUVnWXpedHFWRmNZVUF0; MTYyNDY3OUAzMjMwMmUzMTJlMzBLTWszSTgvbUJFNUZMY0xhdVlpR1VLMW5pSjlpUVZhWkxPNWJ3TnZqeS93PQ ==; MTYyNDY4MEAzMjMwMmUzMTJlMzBIcGViSkRvSzJmV2hCQUI3UjZ2cjZRVlBvODR2a2orRFQwTzYremh6RzBnPQ ==; Mgo + DSMBMAY9C3t2VVhhQlFacF5JXGFWfVJpTGpQdk5xdV9DaVZUTWY / P1ZhSXxQdkFjXH9adXdVRWZeUEY =; MTYyNDY4MkAzMjMwMmUzMTJlMzBZNWo2b0xpVlREZzBZNzAxcDBQTFhhSFZOTDM2cFRaR2s3Zkx6cDFuNUpVPQ ==; MTYyNDY4M0AzMjMwMmUzMTJlMzBjOFVWRG9GTXFOcWJtQlV0Z2ZwWjZQaG1kVkF0b2U5TmF6ZWt1RzRRa29JPQ == ");

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
