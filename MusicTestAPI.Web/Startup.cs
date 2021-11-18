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
using Microsoft.EntityFrameworkCore;
using MusicTestAPI.Data.Interfaces;
using MusicTestAPI.Data;
using MusicTestAPI.Services;
using MusicTestAPI.Services.Interfaces;
using AutoMapper;

namespace MusicTestAPI.Web
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
                c.DocumentFilter<AuthServiceFilter>();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MusicTestAPI.Web", Version = "v1" });
            });
            services.AddDbContext<MusicContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MusicContext"), b => b.MigrationsAssembly("MusicTestAPI.Data")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenAuthenticator, JwtTokenAuthenticator>();
            services.AddScoped<IMusicItemService,AlbumService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(Startup).Assembly, typeof(MusicTestAPI.Services.EntitiesToDTOProfile).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicTestAPI.Web v1"));
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
