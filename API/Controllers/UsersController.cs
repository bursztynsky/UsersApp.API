using System.Net;
using API.Controllers.Models;
using API.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _repo;
    private readonly ILogger<UsersController> _logger;

    public UsersController(
        IUsersRepository repo,
        ILogger<UsersController> logger
    )
    {
        _repo = repo;
        _logger = logger;
    }

    [HttpGet(Name = "Get")]
    public async Task<IActionResult> GetByAmount(int amount)
    {
        try
        {
            var result = await _repo.GetByAmount(amount);

            return new JsonResult(new Result(result));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            
            return new JsonResult(new Result(message: ex.Message, statusCode: HttpStatusCode.InternalServerError));
        }
    }
}