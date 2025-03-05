using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIAgenda.Models;

public class EventAction
{
    [Key]
    public int EventActionId { get; set; }
    [Required]
    [StringLength(100)]
    public string? EventActionName { get; set; }
    [Required]
    [StringLength(500)]
    public string? EventctionDescription { get; set; }
    [Required]
    public ActionType ActionType { get; set; }
    [Required]
    public int EventId { get; set; }
    [Required]
    public Event? Event { get; set; }

}