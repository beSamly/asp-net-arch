using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Product.API.CustomAttributes;
using Product.API.Middleware;

namespace Product.API
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
            // services.AddScoped<IsAuthorizedFilter>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Product.API", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product.API v1"));
            }

            app.UseMiddleware<ExceptionHandler>();
            // app.UseExceptionHandler(exceptionHandlerApp =>
            // {
            //     exceptionHandlerApp.Run(async context =>
            //     {
            //         context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            //
            //         // using static System.Net.Mime.MediaTypeNames;
            //         context.Response.ContentType = MediaTypeNames.Text.Plain;
            //
            //         await context.Response.//("An exception was thrown.");
            //
            //         var exceptionHandlerPathFeature =
            //             context.Features.Get<IExceptionHandlerPathFeature>();
            //
            //         if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
            //         {
            //             await context.Response.WriteAsync(" The file was not found.");
            //         }
            //
            //         if (exceptionHandlerPathFeature?.Path == "/")
            //         {
            //             await context.Response.WriteAsync(" Page: Home.");
            //         }
            //     });
            // });
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}