using System.Text;

namespace EsportsProfileWebApi.Web.Extensions;

public static class CorsService
{   
    public static IServiceCollection AddCustomCors(this IServiceCollection services, WebApplicationBuilder builder)
    {
        var config = builder.Configuration;
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .WithMethods("POST");
                });
        });

        return services;
    }
}
