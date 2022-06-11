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
using MinigamesBusinessLayerMethods;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace MinigamesAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MinigamesAPI", Version = "v1" });
            });
            //add New Db Context:
            //services.AddDbContext<DataContext>(opt =>
            //{
            //    opt.UseSqlServer("Server=tcp:databasetempp3.database.windows.net,1433;Initial Catalog=GamesMicroserviceDB;Persist Security Info=False;User ID=P3Group;Password=Cheeseburger!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //}); //Add in sqlserver connection string once set up
            services.AddScoped<IBusiness, Business>();

            //Configure Cors w/ AAD
            //services.AddCors((options) =>
            //{
            //    options.AddPolicy(name: "dev", builder =>
            //    {
            //        builder
            //        .AllowAnyHeader()
            //        .AllowAnyMethod()
            //        .AllowAnyOrigin();
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MinigamesAPI v1");
                });
            }

            var imagePath = Path.Combine(env.ContentRootPath, "Images");
            if (!Directory.Exists(imagePath))
                Directory.CreateDirectory(imagePath);

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Images")),
                RequestPath = "/Images"

            });
            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UserCors("prod");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
