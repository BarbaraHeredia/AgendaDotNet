using APIAgenda.Models;
using APIAgenda.Request;
using APIAgenda.Response;

namespace APIAgenda.Mappings;

public static class EventEmailMappingExtensions
{
    public static EventEmailResponse ToEventEmailResponse(this EventEmail eventEmail)
    {
        return new EventEmailResponse
        {
            Id = eventEmail.Id,
            Email = eventEmail.Email,
            EmailMessage = eventEmail.EmailMessage,
            EmailSubject = eventEmail.EmailSubject,
            EmailBody = eventEmail.EmailBody,
            EmailRecipient = eventEmail.EmailRecipient,
            EmailAttachments = eventEmail.EmailAttachments,
            DateTime = eventEmail.DateTime,
            EventActionId = eventEmail.EventActionId
        };
    }

    public static EventEmail ToEntity(this PutEventEmailRequest request)
    {
        return new EventEmail
        {
            Id = request.Id,
            Email = request.Email,
            EmailMessage = request.EmailMessage,
            EmailSubject = request.EmailSubject,
            EmailBody = request.EmailBody,
            EmailRecipient = request.EmailRecipient,
            EmailAttachments = request.EmailAttachments,
            DateTime = request.DateTime,
            EventActionId = request.EventActionId
        };
    }
}
