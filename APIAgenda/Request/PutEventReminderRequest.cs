namespace APIAgenda.Request;

public class PutEventReminderRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Created { get; set; }
    public DateTime SentDate { get; set; }
    public int EventActionId { get; set; }
}
