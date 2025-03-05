namespace APIAgenda.Request;

public class PutEventMessageRequest
{
    public int Id { get; set; }
    public string MessageBody { get; set; }
    public string MessageRecipient { get; set; }
    public DateTime MessageCreated { get; set; }
    public int EventActionId { get; set; }
}
