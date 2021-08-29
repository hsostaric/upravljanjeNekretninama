using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendDioPrediction.HouseCommon.InputOutput;
using BackendDioPrediction.Interfaces;
using BackendDioPrediction.Interfaces.Interfaces;
using BackendDioPrediction.Models.DbModels;
using BackendDioPrediction.Repository.Repositories;
using BackendDioPrediction.Services.HouseDatabaseServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ML;

namespace BackendDioPrediction
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
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IHouseService, HouseService>();
            services.AddPredictionEnginePool<HouseData, HouseOutput>()
           .FromFile(modelName: "HouseValuePredictModel", filePath: "./MLModel.zip", watchForChanges: true);
            services.AddControllers();

            services.AddCors(c =>
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
