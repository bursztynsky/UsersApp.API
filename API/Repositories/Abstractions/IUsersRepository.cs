using API.Repositories.Dtos;

namespace API.Repositories.Abstractions;

public interface IUsersRepository
{
    Task<IEnumerable<UserDto>> GetByAmount(int amount);
}