using Invio.Application.Handlers;
using Invio.Application.Interfaces;
using Invio.Application.Services;
using Invio.Domain.Notifications;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Application.Configurations;
public static class ConfigurationModule
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(new List<Notificacao>());
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<INotificationHandler, NotificationHandler>();

        //services.AddHttpClient();

        //services.AddCors(options =>
        //{
        //    options.AddPolicy("AllowSpecificOrigin",
        //        builder => builder
        //            .WithOrigins("http://localhost:4200")
        //            .AllowAnyHeader()
        //            .AllowAnyMethod());
        //});

        //services.AddControllers();

        
        var info = new OpenApiInfo();
        info.Version = "V1";
        info.Title = "API Invio - Gestão de Usuarios";

        //services.AddSwaggerGen(c =>
        //{
        //    c.SwaggerDoc("v1", info);
        //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //    {
        //        Description = "Insira o token JWT desta maneira : Bearer {seu token}",
        //        Name = "Authorization",
        //        BearerFormat = "JWT",
        //        In = ParameterLocation.Header,
        //        Type = SecuritySchemeType.ApiKey,
        //        Scheme = "Bearer"

        //    });
        //    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        //        {
        //            {
        //                new OpenApiSecurityScheme
        //                {
        //                    Reference = new OpenApiReference
        //                    {
        //                        Type = ReferenceType.SecurityScheme,
        //                        Id = "Bearer"
        //                    },
        //                    Scheme = "oauth2",
        //                    Name = "Bearer",
        //                    In= ParameterLocation.Header,

        //                },
        //                new List<string>()
        //            }
        //        });
        //});

        return services;
    }
}
