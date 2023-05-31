using API.Services.RandomUserApi.Models;

namespace API.Services.RandomUserApi.Abstractions;

public interface IRandomUsersApi
{
    Task<IEnumerable<RandomUserDto>> Get(int amount);
}