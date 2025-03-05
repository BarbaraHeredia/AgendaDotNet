using APIAgenda.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIAgenda.Response;

//InsertUserRequest
//UpdateUserRequest
//UserResponse

public class UserResponse
{
    public string Id { get; set; }

    public string UserName { get; set; }

    public string UserUrl { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

}
