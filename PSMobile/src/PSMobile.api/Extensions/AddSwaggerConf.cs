using Microsoft.OpenApi.Models;

namespace PSMobile.api.Extensions;

public static class AddSwaggerConf
{

    public static WebApplicationBuilder AddSwaggerConfig(this WebApplicationBuilder builder)
    {

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IncludeFields = true;
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "API Teste",
                Description = "API para Teste",
                Contact = new OpenApiContact
                {
                    Name = "Rubens",
                    Email = "rubens@plugsoft.net",
                }
            }
            );

            //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //{
            //    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
            //    Name = "Authorization",
            //    Scheme = "Bearer",
            //    BearerFormat = "JWT",
            //    In = ParameterLocation.Header,
            //    Type = SecuritySchemeType.ApiKey
            //});

            //c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //{
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "Bearer"
            //                }
            //            },
            //            new string[] {}
            //        }
            //});
        });

        return builder;
    }

}

