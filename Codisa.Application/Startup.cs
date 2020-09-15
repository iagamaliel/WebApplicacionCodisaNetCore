using System;
using System.Reflection;
using AutoMapper;
using Codisa.Application.Mapping;
using Codisa.Infrastructure.Interfaces;
using Codisa.Infrastructure.Mapping;
using Codisa.Infrastructure.Repository;
using Codisa.Infrastructure.Repository.InterfacesRepository;
using Codisa.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codisa.Application
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddAutoMapper(new Assembly[] { typeof(InfrastructureMapping).GetTypeInfo().Assembly});
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new InfrastructureMapping());
                mc.AddProfile(new ApplicationMapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<IEmpleadoHabilidadRepository, EmpleadoHabilidadRepository>();

            services.AddScoped<IAreaServices>(sp =>
            {
                return new AreaServices(Configuration.GetConnectionString("DevConnection"));
            });

            services.AddScoped<IEmpleadoServices>(sp =>
            {
                return new EmpleadoServices(Configuration.GetConnectionString("DevConnection"));
            });

            services.AddScoped<IEmpleadoHabilidadServices>(sp =>
            {
                return new EmpleadoHabilidadServices(Configuration.GetConnectionString("DevConnection"));
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Area}/{action=Index}/{id?}");
            });
        }
    }
}
