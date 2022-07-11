using System;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Romarinho.Api.DTOs;
using Romarinho.Application;
using Romarinho.Core;
using Romarinho.Domain.Model;

namespace Romarinho.Api
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
            Initializer.Configure(services, Configuration.GetConnectionString("DefaultConnection"));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrdemDTO, Ordem>();
                cfg.CreateMap<IEnumerable<OrdemDTO>, IEnumerable<Ordem>>();
                cfg.CreateMap<Ordem, OrdemDTO>();
                cfg.CreateMap<IEnumerable<Ordem>, IEnumerable<OrdemDTO>>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

