using APIAgenda.Models;

namespace APIAgenda.Response;

public class EventActionResponse
{
    public int EventActionId { get; set; }
    public string EventActionName { get; set; }
    public string EventctionDescription { get; set; }
    public ActionType ActionType { get; set; }
    public int EventId { get; set; }
}
