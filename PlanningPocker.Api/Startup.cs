using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.OpenApi.Models;
using PlanningPocker.Repository.Context;
using PlanningPocker.Repository.Interfaces;
using PlanningPocker.Repository.Repositories;
using PlanningPocker.Service.Interfaces;
using PlanningPocker.Service.Services;

namespace PlanningPocker.Api
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
            
            services.AddTransient<ICartaService, CartaService>();
            services.AddTransient<ICartaRepository, CartaRepository>();

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IHistoriaDoUsuarioService, HistoriaDoUsuarioService>();
            services.AddTransient<IHistoriaDoUsuarioRepository, HistoriaDoUsuarioRepository>();

            services.AddTransient<IVotoService, VotoService>();
            services.AddTransient<IVotoRepository, VotoRepository>();

            services.AddEntityFrameworkNpgsql().AddDbContext<PlanningPockerContext>
            (optionsAction: x => x.UseNpgsql(PlanningPockerContext.GetConnectionString()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlanningPocker.Api", Version = "v1" });
            });
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
                        c.RoutePrefix = "swagger";
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlanningPocker.Api v1");
                    });
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
