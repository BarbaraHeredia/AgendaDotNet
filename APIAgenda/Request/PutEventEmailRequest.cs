namespace APIAgenda.Request;

public class PutEventEmailRequest
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string EmailMessage { get; set; }
    public string EmailSubject { get; set; }
    public string EmailBody { get; set; }
    public string EmailRecipient { get; set; }
    public string EmailAttachments { get; set; }
    public DateTime DateTime { get; set; }
    public int EventActionId { get; set; }
}
