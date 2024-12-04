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

        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder
                    .WithOrigins("http://localhost:4200") // Seu front-end
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()); // Permite cookies
        });


        var info = new OpenApiInfo();
        info.Version = "V1";
        info.Title = "API Invio - Gestão de Usuarios";

        return services;
    }
}
