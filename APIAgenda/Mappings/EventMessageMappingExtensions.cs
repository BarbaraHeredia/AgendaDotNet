using APIAgenda.Models;
using APIAgenda.Request;
using APIAgenda.Response;

namespace APIAgenda.Mappings
{
    public static class EventMessageMappingExtensions
    {
        public static EventMessageResponse ToEventMessageResponse(this EventMessage eventMessage)
        {
            return new EventMessageResponse
            {
                Id = eventMessage.Id,
                MessageBody = eventMessage.MessageBody,
                MessageRecipient = eventMessage.MessageRecipient,
                MessageCreated = eventMessage.MessageCreated,
                EventActionId = eventMessage.EventActionId
            };
        }

        public static EventMessage ToEntity(this PutEventMessageRequest request)
        {
            return new EventMessage
            {
                Id = request.Id,
                MessageBody = request.MessageBody,
                MessageRecipient = request.MessageRecipient,
                MessageCreated = request.MessageCreated,
                EventActionId = request.EventActionId
            };
        }
    }
}
