using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Restaurante.Infrastructure.Data;

namespace Restaurante.UI.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //teste git
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(ConfigureJson);

            services.AddDbContext<RestauranteContext>(options =>
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=cadrest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

            services.AddScoped(typeof(ApplicationCore.Interfaces.Repository.IGenericRepository<>), typeof(Infrastructure.Repository.GenericRepository<>));
            services.AddScoped<ApplicationCore.Interfaces.Service.IPratosService, ApplicationCore.Services.PratoService>();
            services.AddScoped<ApplicationCore.Interfaces.Service.IRestauranteService, ApplicationCore.Services.RestauranteService>();
            //services.AddTransient<ApplicationCore.Interfaces.Service.IPratosService, ApplicationCore.Services.PratoService>();
            //services.AddTransient<ApplicationCore.Interfaces.Service.IRestauranteService, ApplicationCore.Services.RestauranteService>();

        }

        private void ConfigureJson(MvcJsonOptions obj)
        {
            obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
