using APIAgenda.Models;
using APIAgenda.Request;
using APIAgenda.Response;

namespace APIAgenda.Extensions;

public static class UserMappingExtensions
{
    public static UserResponse ToUserResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            UserName = user.UserName,
            UserUrl = user.UserUrl,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };
    }

    public static User ToEntity(this PutUserRequest request)
    {
        return new User
        {
            Id = request.Id,
            UserName = request.UserName,
            UserUrl = request.UserUrl,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };
    }

    public static UserEventResponse ToUserEventResponse(this Event evnt)
    {
        return new UserEventResponse
        {
            Id = evnt.Id,
            EventName = evnt.EventName,
            EventDescription = evnt.EventDescription,
            EventDateStart = evnt.EventDateStart,
            EventDateEnd = evnt.EventDateEnd,
            UserId = evnt.UserId
        };
    }
}
