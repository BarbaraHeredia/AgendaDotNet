namespace APIAgenda.Response;

public class EventMessageResponse
{
    public int Id { get; set; }
    public string MessageBody { get; set; }
    public string MessageRecipient { get; set; }
    public DateTime MessageCreated { get; set; }
    public int EventActionId { get; set; }
}
