using APIAgenda.Models;
using APIAgenda.Request;
using APIAgenda.Response;

namespace APIAgenda.Mappings;

public static class EventActionMappingExtensions
{
    public static EventActionResponse ToEventActionResponse(this EventAction eventAction)
    {
        return new EventActionResponse
        {
            EventActionId = eventAction.EventActionId,
            EventActionName = eventAction.EventActionName,
            EventctionDescription = eventAction.EventctionDescription,
            ActionType = eventAction.ActionType,
            EventId = eventAction.EventId
        };
    }

    public static EventAction ToEntity(this PutEventActionRequest request)
    {
        return new EventAction
        {
            EventActionId = request.EventActionId,
            EventActionName = request.EventActionName,
            EventctionDescription = request.EventctionDescription,
            ActionType = request.ActionType,
            EventId = request.EventId
        };
    }
}
