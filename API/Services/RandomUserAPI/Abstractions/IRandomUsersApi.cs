using API.Services.RandomUserApi.Dtos;

namespace API.Services.RandomUserApi.Abstractions;

public interface IRandomUsersApi
{
    Task<IEnumerable<RandomUserDto>> Get(int amount);
}