using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure.Data;
using API.Middleware;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data.RepoConfig;
using API.Helpers;
using AutoMapper;

namespace API
{
    public class Startup
    {
       
        public IConfiguration _config { get; set; }
        public Startup(IConfiguration configuration)
        {

            _config = configuration;
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MainContext>(x => x.UseSqlite(_config.GetConnectionString("appConnection")));
            services.AddAutoMapper(typeof(MappingProfiles)); 
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers();
            services.Configure<ApiBehaviorOptions>(options => 
                options.InvalidModelStateResponseFactory = actionContext => {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x=> x.Value.Errors)
                        .Select(x=>x.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidationErrorResponse {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                }
            ); 
                services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    // policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"); 
                    //client application
                      policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //invoke this middleware before others.
            app.UseMiddleware<ExceptionMiddleware>();
             app.UseStatusCodePagesWithReExecute("/errors/{0}");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
