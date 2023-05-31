using API.Services.RandomUserAPI;
using API.Services.RandomUserAPI.Abstractions;

namespace API.Services;

public static class StartupExtension
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RandomUsersAPIConfig>(configuration.GetSection(nameof(RandomUsersAPI)));
        services.AddTransient<IRandomUsersAPI, RandomUsersAPI>();
    }
}