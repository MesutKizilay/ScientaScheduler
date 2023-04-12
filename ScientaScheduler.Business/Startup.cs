using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ScientaScheduler.Business.Authentication;
using ScientaScheduler.Business.Hubs;
using ScientaScheduler.Business.Services.Infrstructure;
using ScientaScheduler.Business.Services.Interface;
using ScientaSchedurler.Application.DataAccess;
using ScientaSchedurler.Application.DataAccess.EntityFramework;
using ScientaSchedurler.Application.Infrastucture;
using ScientaSchedurler.Application.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ScientaScheduler.Business
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
            services.AddSignalR();
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults
                .MimeTypes.Concat(new[] { "application/octet-stream" });
            });

            //services.AddControllers(options =>
            //{
            //    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
            //    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
            //    {
            //        ReferenceHandler = ReferenceHandler.Preserve,
            //    }));
            //});

            //services
            //    .AddControllers()
            //    .AddJsonOptions(options =>
            //    {
            //        options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            //        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            //    });



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ScientaScheduler.Business", Version = "v1" });
            });

            var _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _tokenOptions.Issuer,
                    ValidAudience = _tokenOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddTransient<IProject, ProjectHandler>();
            services.AddTransient<ITask, TaskHandler>();
            services.AddTransient<ITaskService, TaskManager>();
            services.AddSingleton(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<>));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScientaScheduler.Business v1"));
            }

            app.UseResponseCompression();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chathub");
            });
        }
    }
}
