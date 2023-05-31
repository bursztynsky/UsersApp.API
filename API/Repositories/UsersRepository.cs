using API.Repositories.Abstractions;
using API.Repositories.Dtos;
using API.Services.RandomUserApi.Abstractions;
using API.Services.RandomUserApi.Models;

namespace API.Repositories;

public class UsersRepository : IUsersRepository
{
    #region Conversions

    private static readonly Func<RandomUserDto, UserDto> ConvertToDto = e => new UserDto
    {
        Name = e.Name.First,
        Surname = e.Name.Last,
        Email = e.Email,
    };

    #endregion

    private readonly IRandomUsersApi _randomUsersApi;

    public UsersRepository(
        IRandomUsersApi randomUsersApi
    )
    {
        _randomUsersApi = randomUsersApi;
    }

    public async Task<IEnumerable<UserDto>> GetByAmount(int amount)
    {
        Validate(amount);

        var result = (await _randomUsersApi.Get(amount))
            .Select(e => ConvertToDto(e))
            .ToList();

        return result;
    }

    private void Validate(int amount)
    {
        if (amount <= 0)
            throw new Exception("The amount have to be more than 0.");

        if (amount > 200)
            throw new Exception("The maximum amount it 200.");
    }
}