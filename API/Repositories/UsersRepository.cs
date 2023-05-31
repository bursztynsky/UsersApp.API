using API.DTOs;
using API.Repositories.Abstractions;
using API.Services.RandomUserAPI.Abstractions;

namespace API.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly IRandomUsersAPI _randomUsersApi;

    public UsersRepository(
        IRandomUsersAPI randomUsersApi
    )
    {
        _randomUsersApi = randomUsersApi;
    }

    public async Task<UserDTO> GetByAmount(int amount)
    {
        var result = await _randomUsersApi.Get(amount);

        return new UserDTO();
    }
}