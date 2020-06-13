using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SIZCapi.Data;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SIZCapi
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
            services.AddDbContext<SIZCKontekst>(opcje => opcje.UseSqlServer
                (Configuration.GetConnectionString("SIZCConnection")));

            services.AddControllers().AddNewtonsoftJson(opcje => 
                {
                    opcje.SerializerSettings.ContractResolver = 
                    new CamelCasePropertyNamesContractResolver();
                    
                    opcje.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                }
            );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddCors();

            services.AddScoped<ISIZCRepozytorium, SqlSIZCRepozytorium>();

            services.AddScoped<IAutoryzacjaKlient, AutoryzacjaKlient>();

            services.AddScoped<IAutoryzacjaPracownik, AutoryzacjaPracownik>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opcje => 
                {
                    opcje.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.Unicode
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("WymaganeUprawnieniaPracownika",
                    policy => policy.RequireClaim("UprawnieniaPracownik"));

                options.AddPolicy("WymaganeUprawnieniaAdministartora",
                    policy => policy.RequireClaim("UprawnieniaKucharz"));

                options.AddPolicy("WymaganeUprawnieniaKlienta",
                    policy => policy.RequireClaim("UprawnieniaKlient"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(e => e.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
