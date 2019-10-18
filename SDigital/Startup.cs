using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SDigital.Configurations;
using System;

namespace SDigital
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .ConfigureApiBehaviorOptions(opt => opt.SuppressMapClientErrors = true)
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddOptions();
            services.ConfigurarDependencias();
            //services.ConfigurarSwagger();
            services.ConfigurarHealthChecks(Configuration);
            services.AddHttpContextAccessor();
            services.ConfigurarAutorizacao();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            //app.UtilizarConfiguracaoSwagger();
            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
            });
            app.UtilizarConfiguracaoAutorizacao();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}