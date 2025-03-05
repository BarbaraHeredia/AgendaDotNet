using System.ComponentModel.DataAnnotations;

namespace Agenda.Domain.Models;

public class EventReminder
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(200)]
    public string Name { get; set; }
    [Required]
    [StringLength(200)]
    public string Title { get; set; }
    [Required]
    [StringLength(2000)]
    public string Content { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Created { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime SentDate { get; set; }
    [Required]
    public int EventActionId { get; set; }
    [Required]
    public EventAction? EventAction { get; set; }
}
