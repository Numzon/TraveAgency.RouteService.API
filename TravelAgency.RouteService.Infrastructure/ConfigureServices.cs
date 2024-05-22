using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TravelAgency.RouteService.Infrastructure.Configurations;
using TravelAgency.RouteService.Infrastructure.Persistance;
using TravelAgency.SharedLibrary.AWS;
using TravelAgency.SharedLibrary.Models;
using TravelAgency.SharedLibrary.RabbitMQ;

namespace TravelAgency.RouteService.Infrastructure;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var connectionString = builder.Configuration.GetConnectionString("RouteServiceDatabase");

        builder.Services.AddDbContext<RouteServiceDbContext>(options =>
                options.UseNpgsql(connectionString, builder => builder.MigrationsAssembly(typeof(RouteServiceDbContext).Assembly.FullName)));

        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.RegisterDatabaseTools();
        services.RegisterRepositories();
        services.RegisterServices();
        services.RegisterPublishers();

        builder.Services.Configure<RabbitMqSettingsDto>(builder.Configuration.GetRequiredSection("RabbitMQ"));
        builder.Services.Configure<AwsCognitoSettingsDto>(builder.Configuration.GetRequiredSection("AWS:Cognito"));

        try
        {
            var cognitoConfiguration = builder.Configuration.GetRequiredSection("AWS:Cognito").Get<AwsCognitoSettingsDto>()!;
            builder.Services.AddAuthenticationAndJwtConfiguration(cognitoConfiguration);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }

        try
        {
            var rabbitMqSettings = builder.Configuration.GetRequiredSection("RabbitMQ").Get<RabbitMqSettingsDto>()!;
            builder.Services.AddRabbitMqConfiguration(rabbitMqSettings);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }

        builder.Services.AddSingleton(EventStrategyConfiguration.GetGlobalSettingsConfiguration());

        services.AddAuthorizationWithPolicies();

        return services;
    }
}
