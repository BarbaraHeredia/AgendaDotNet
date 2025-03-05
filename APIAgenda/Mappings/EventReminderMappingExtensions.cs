using APIAgenda.Models;
using APIAgenda.Request;
using APIAgenda.Response;

namespace APIAgenda.Mappings;

public static class EventReminderMappingExtensions
{
    public static EventReminderResponse ToEventReminderResponse(this EventReminder eventReminder)
    {
        return new EventReminderResponse
        {
            Id = eventReminder.Id,
            Name = eventReminder.Name,
            Title = eventReminder.Title,
            Content = eventReminder.Content,
            Created = eventReminder.Created,
            SentDate = eventReminder.SentDate,
            EventActionId = eventReminder.EventActionId
        };
    }

    public static EventReminder ToEntity(this PutEventReminderRequest request)
    {
        return new EventReminder
        {
            Id = request.Id,
            Name = request.Name,
            Title = request.Title,
            Content = request.Content,
            Created = request.Created,
            SentDate = request.SentDate,
            EventActionId = request.EventActionId
        };
    }
}
