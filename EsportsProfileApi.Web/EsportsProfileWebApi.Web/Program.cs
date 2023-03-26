using EsportsProfileWebApi.DOMAIN;
using EsportsProfileWebApi.INFRASTRUCTURE;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontend = configuration.GetValue<string>("front-end-url");
    options.AddDefaultPolicy(builder => builder.WithOrigins(frontend).AllowAnyMethod().AllowAnyHeader());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPlayerOrchestrator,PlayerOrchestrator>();
builder.Services.AddTransient<IPlayerRepository,PlayerRepository>();
builder.Services.AddTransient<ISettingsOrchestrator, SettingsOrchestrator>();
builder.Services.AddTransient<ISettingsRepository, SettingsRepository>();
builder.Services.AddTransient<IPeripheralOrchestrator, PeripheralOrchestrator>();
builder.Services.AddTransient<IPeripheralsRepository, PeripheralsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
