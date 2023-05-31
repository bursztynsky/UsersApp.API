using API.Repositories.Abstractions;

namespace API.Repositories;

public static class StartupExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUsersRepository, UsersRepository>();
    }
}