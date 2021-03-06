using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PetShopApplication.Core.ApplicationService;
using PetShopApplication.Core.ApplicationService.Impl;
using PetShopApplication.Core.DomainService;
using PetShopApplication.Core.Entities;
using PetShopApplicationSolution.Infrastructure.Data;
using PetShopApplicationSolution.Infrastructure.Data.Helpers;
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
            // Create a byte array with random values. This byte array is used
            // to generate a key for signing JWT tokens.
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };

            });


            services.AddControllers().AddNewtonsoftJson();


            services.AddDbContext<PetShopApplicationContext>(
               opt => opt.UseSqlite("Data Source = petshopApplication.db")
               );

            // Register repositories for dependency injection
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IPetColorRepository, PetColorRepository>();
            services.AddScoped<IToDoRepository, ToDoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<IPetColorService, PetColorService>();
            

            // Register database initializer
            services.AddTransient<IDBInitializer, DBInitializer>();

            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));

            services.AddCors(options => 
                    options.AddDefaultPolicy(  builder => {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                            })
                    );

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            
            services.AddSwaggerGen();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "PetShop Api",
                        Description = "PetShop Swagger",
                        Version = "V1"
                    });
                var fileName = $"{ Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(filePath);
            });

            services.AddControllers();
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
                    var services = scope.ServiceProvider;
                    var ptx = scope.ServiceProvider.GetService<PetShopApplicationContext>();
                    var dbInitializer = services.GetService<IDBInitializer>();
                    dbInitializer.SeedDB(ptx);
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
