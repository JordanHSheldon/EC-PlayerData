namespace EsportsProfileWebApi.Web.Extensions;

public class CorsService(IConfiguration config)
{
    private readonly IConfiguration _config = config ?? throw new NotImplementedException();
    
    public void AddCors(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins(_config
                           .GetValue<string>("front-end-url") ?? throw new NotImplementedException())
                           .WithMethods("POST");
                });
        });
    }
}
