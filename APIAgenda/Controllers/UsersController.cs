using APIAgenda.Response;
using APIAgenda.Request;
using APIAgenda.Extensions;
using APIAgenda.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAgenda.Pagination;
using Microsoft.AspNetCore.Mvc.RazorPages;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public UsersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("Events/{userId}")]
    public async Task<ActionResult<IEnumerable<UserEventResponse>>> GetUserEvents(string userId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var paginationParameters = new PaginationParameters { PageNumber = page, PageSize = pageSize };
        var events = await _unitOfWork.UserRepository.GetEventsByUserIdAsync(userId, paginationParameters);
        if (events == null || !events.Any())
        {
            return NotFound("Eventos não encontrados para o usuário informado");
        }

        var eventDtos = events.Select(e => e.ToUserEventResponse()).ToList();
        return Ok(eventDtos);
    }

    [HttpGet("pagination")]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetUsersPagination([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var paginationParameters = new PaginationParameters { PageNumber = page, PageSize = pageSize };
        var users = await _unitOfWork.UserRepository.GetUsersAsync(paginationParameters);
        if (!users.Any())
        {
            return NotFound("Usuários não encontrados");
        }
        var userDtos = users.Select(user => user.ToUserResponse()).ToList();
        return Ok(userDtos);
    }


    [HttpGet("{id}", Name = "ObterUsuario")]
    public async Task<ActionResult<UserResponse>> Get(string id)
    {
        var user = await _unitOfWork.UserRepository.GetUserAsync(id);

        if (user == null)
        {
            return NotFound("Usuário não encontrado");
        }

        var userDto = user.ToUserResponse();

        return Ok(userDto);
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> Post(PutUserRequest userDto)
    {
        if (userDto == null)
        {
            return BadRequest();
        }

        var user = userDto.ToEntity();

        var result = await _unitOfWork.UserRepository.CreateAsync(user);
        await _unitOfWork.CommitAsync(); 
        var userGetDto = user.ToUserResponse();

        return new CreatedAtRouteResult("ObterUsuario", new { id = user.Id }, userGetDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(string id, PutUserRequest putUserRequest)
    {
        if (putUserRequest == null)
        {
            return BadRequest();
        }

        var existingUser = await _unitOfWork.UserRepository.GetUserAsync(id);
        if (existingUser == null)
        {
            return NotFound("Usuário não encontrado");
        }

        var newUser = putUserRequest.ToEntity();
        existingUser.UserName = newUser.UserName;
        existingUser.UserUrl = newUser.UserUrl;
        existingUser.Email = newUser.Email;
        existingUser.PhoneNumber = newUser.PhoneNumber;

        await _unitOfWork.UserRepository.UpdateAsync(existingUser);
        await _unitOfWork.CommitAsync(); 

        return Ok(newUser.ToUserResponse());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var user = await _unitOfWork.UserRepository.GetUserAsync(id);
        if (user == null)
        {
            return NotFound("Usuário não encontrado");
        }

        await _unitOfWork.UserRepository.DeleteAsync(id);
        await _unitOfWork.CommitAsync(); 

        return Ok(user.ToUserResponse());
    }
}
