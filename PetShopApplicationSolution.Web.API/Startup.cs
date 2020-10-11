using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PetShopApplication.Core.ApplicationService;
using PetShopApplication.Core.ApplicationService.Impl;
using PetShopApplication.Core.DomainService;
using PetShopApplication.Core.Entities;
using PetShopApplicationSolution.Infrastructure.Data;
//using PetShopApplication.Infrastructure.Data;
//using PetShopApplication.Infrastructure.Static.Data;
//using PetShopApplication.Infrastucture.SQL;
using PetShopApplicationSolution.Infrastructure.Data.Repositories;

namespace PetShopApplicationSolution.Web.API
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
            services.AddControllers().AddNewtonsoftJson();

            //services.AddDbContext<PetShopApplicationContext>(
            //    opt => opt.UseInMemoryDatabase("ThaDB")
            //    );

            services.AddDbContext<PetShopApplicationContext>(
               opt => opt.UseSqlite("Data Source = petshopApplication.db")
               );

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();

            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddControllers();
            services.AddSwaggerGen();

            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("V1",
            //        new Microsoft.OpenApi.Models.OpenApiInfo
            //        {
            //            Title = "PetShop Api",
            //            Description = "PetShop Swagger",
            //            Version = "V1"
            //        });
            //    var fileName = $"{ Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
            //    //options.IncludeXmlComments(filePath);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using(var scope = app.ApplicationServices.CreateScope())
                {
                    var ptx = scope.ServiceProvider.GetService<PetShopApplicationContext>();
                    DBInitializer.SeedDB(ptx);
                }
            }
            else if (env.IsProduction())
            {

            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var ownerRepo = scope.ServiceProvider.GetService<IOwnerRepository>();
                var petRepo = scope.ServiceProvider.GetService<IPetRepository>();
                var petTypeRepo = scope.ServiceProvider.GetService<IPetTypeRepository>();
                //new FakeDB(ownerRepo, petRepo, petTypeRepo).InitData();
            }

            app.UseHttpsRedirection();


            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PetShop Api V1");
                options.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        
        }

    }
}
