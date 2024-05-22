using TravelAgency.SharedLibrary.RabbitMQ;

namespace TravelAgency.RouteService.Infrastructure.Configurations;
public static class EventStrategyConfiguration
{
    public static TypeEventStrategyConfig GetGlobalSettingsConfiguration()
    {
        var config = TypeEventStrategyConfig.GlobalSetting;

        return config;
    }
}
