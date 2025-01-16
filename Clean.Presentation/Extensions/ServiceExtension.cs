using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Application.Interfaces;
using Clean.Application.LoggerServices;
using Clean.Application.Services;
using Clean.Infrastructure.Data;
using Clean.Infrastructure.LoggerServices;
using Clean.Infrastructure.Models;
using Clean.Infrastructure.Repositories;
using Clean.Presentation.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Clean.Presentation.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("Default"));
            });
        }
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = config["JWT:Issuer"],
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!)),
                    ValidateLifetime = true
                };
            });
        }

        public static void ConfigureEntity(this IServiceCollection services)
        {
            services.AddIdentity<Usuario, Cargo>(options =>
            {
                options.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }

        public static void ConfigurateAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("SudoPolicy", p => p.RequireRole("Sudo"));
            });
        }

        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ILoggerManager, LoggerManager>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ITokenServices, TokenServices>();
        }
    }
}