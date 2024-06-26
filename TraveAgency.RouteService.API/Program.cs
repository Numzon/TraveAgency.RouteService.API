using System.Reflection;
using TravelAgency.RouteService.Application;
using TravelAgency.RouteService.Infrastructure;
using TravelAgency.SharedLibrary.Swagger;
using TravelAgency.SharedLibrary.Vault.Consts;
using TravelAgency.SharedLibrary.Vault;
using TravelAgency.RouteService.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
if (builder.Environment.IsDevelopment())
{
    Assembly assembly = typeof(Program).Assembly;
    builder.Services.AddAndConfigureSwagger(assembly.GetName().Name!);
}

if (builder.Environment.IsProduction())
{
    var vaultBuilder = new VaultFacadeBuilder();

    var vaultFacade = vaultBuilder
                        .SetToken(Environment.GetEnvironmentVariable(VaultEnvironmentVariables.Token))
                        .SetPort(Environment.GetEnvironmentVariable(VaultEnvironmentVariables.Port))
                        .SetHost(Environment.GetEnvironmentVariable(VaultEnvironmentVariables.Host))
                        .SetSSL(false)
                        .Build();

    var rabbitMq = await vaultFacade.ReadRabbitMqSecretAsync();
    var database = await vaultFacade.ReadRouteServiceConnectionStringSecretAsync();
    var cognito = await vaultFacade.ReadCognitoSecretAsync();

    builder.Configuration.AddInMemoryCollection(rabbitMq);
    builder.Configuration.AddInMemoryCollection(database);
    builder.Configuration.AddInMemoryCollection(cognito);
}

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
       .UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<RouteServiceDbContextInitialiser>();
        await initialiser.InitialiseAsync();
    }
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

#pragma warning disable S1118 // Utility classes should not have public constructors
public partial class Program { }
#pragma warning restore S1118 // Utility classes should not have public constructors