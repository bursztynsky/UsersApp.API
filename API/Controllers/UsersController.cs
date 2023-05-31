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

    public UsersController(
        IUsersRepository repo
    )
    {
        _repo = repo;
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
            // todo: log error

            return new JsonResult(new Result(message: ex.Message, statusCode: HttpStatusCode.InternalServerError));
        }
    }
}