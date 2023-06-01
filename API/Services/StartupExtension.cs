using API.Services.RandomUserApi;
using API.Services.RandomUserApi.Abstractions;

namespace API.Services;

public static class StartupExtension
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RandomUsersApiConfig>(configuration.GetSection(nameof(RandomUsersApi)));
        services.AddTransient<IRandomUsersApi, RandomUsersApi>();
    }
}