using BarbershopCalendar.Application;
using BarbershopCalendar.Application.Interface;
using BarbershopCalendar.Persistence;
using BarbershopCalendar.Persistence.DataContext;
using BarbershopCalendar.Persistence.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShopCalendar.API
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
            services.AddDbContext<BarbershopContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("Default")));

            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings
                    .ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddCors(); 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BarberShopCalendar.API", Version = "v1" });
            });

            services.AddScoped<IDayAppointmentService, DayAppointmentService>();
            services.AddScoped<ICommonPersist, CommonPersist>();
            services.AddScoped<IDayAppointmentPersist, DayAppointmentPersist>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BarberShopCalendar.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(acess => acess.AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
