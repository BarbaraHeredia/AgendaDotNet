using APIAgenda.Models;
using APIAgenda.Request;
using APIAgenda.Response;

namespace APIAgenda.Mappings;

public static class EventMappingExtensions
{
    public static EventResponse ToEventResponse(this Event evnt)
    {
        return new EventResponse
        {
            Id = evnt.Id,
            EventName = evnt.EventName,
            EventDescription = evnt.EventDescription,
            EventDateStart = evnt.EventDateStart, 
            EventDateEnd = evnt.EventDateEnd, 
            UserId = evnt.UserId
        };
    }

    public static Event ToEntity(this PutEventRequest request)
    {
        return new Event
        {
            Id = request.Id,
            EventName = request.EventName,
            EventDescription = request.EventDescription,
            EventDateStart = request.EventDateStart, 
            EventDateEnd = request.EventDateEnd, 
            UserId = request.UserId
        };
    }
}
