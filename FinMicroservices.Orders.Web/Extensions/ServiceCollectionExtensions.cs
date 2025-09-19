using FinMicroservices.Orders.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace FinMicroservices.Orders.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Orders API",
                Version = "v1"
            });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            //кнопка для сваггера авторизации
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"

                    }
                },
                Array.Empty<string>()
                }
            });
        });
        return builder;
    }

    public static WebApplicationBuilder AddData(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<OrdersDbContext>(opt =>
            opt.UseNpgsql(builder.Configuration.GetConnectionString("Orders")));
        return builder;
    }
    public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
    {
        return builder;
    }
    public static WebApplicationBuilder AddIntegrationServices(this WebApplicationBuilder builder)
    {
        return builder;
    }
}