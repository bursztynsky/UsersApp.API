using API.DTOs;

namespace API.Repositories.Abstractions;

public interface IUsersRepository
{
    Task<UserDTO> GetByAmount(int amount);
}