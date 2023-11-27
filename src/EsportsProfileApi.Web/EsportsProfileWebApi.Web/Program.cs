using EsportsProfileWebApi.DOMAIN;
using EsportsProfileWebApi.DOMAIN.Orchestrators.Settings;
using EsportsProfileWebApi.INFRASTRUCTURE;
using EsportsProfileWebApi.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJwtAuthentication(builder);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerJwtBearer();
builder.Services.AddSingleton<IDataOrchestrator, DataOrchestrator>();
builder.Services.AddSingleton<IDataRepository, DataRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();