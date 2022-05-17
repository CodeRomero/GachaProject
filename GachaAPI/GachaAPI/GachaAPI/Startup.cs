using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GachaMainBusinessMethods;

namespace GachaAPI
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
            //Update old cors
            //services.AddCors((options) =>
            //{
            //    options.AddPolicy(name: "dev", builder =>
            //    {
            //        builder.WithOrigins("http://127.0.0.1:5500",
            //            "http://localhost:4200",
            //            "https://localhost:44307",
            //            "https://pokelootapi.azurewebsites.net",
            //            "https://pokeloot.azurewebsites.net/",
            //            "https://pokeloot.z19.web.core.windows.net/",
            //            "http://20.106.64.124/")
            //        // update thisssssssssss to proper ip / pathing
            //        .AllowAnyHeader()
            //        .AllowAnyMethod();
            //    });
            //});
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GachaAPI", Version = "v1" });
            });
            //rescaffold new DB
            //services.AddDbContext<P3DbClass>(options =>
            //{
            //    if (!options.IsConfigured)
            //    {
            //        options.UseSqlServer("Server=tcp:databasetempp3.database.windows.net,1433;Initial Catalog=P3Database;Persist Security Info=False;User ID=P3Group;Password=Cheeseburger!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //    }
            //});
            services.AddScoped<IBusiness, Business>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GachaAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            //app.UseCors("prod");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
