using API.Services.RandomUserAPI.Models;

namespace API.Services.RandomUserAPI.Abstractions;

public interface IRandomUsersAPI
{
    Task<IEnumerable<RandomUserAPIModel>> Get(int amount);
}