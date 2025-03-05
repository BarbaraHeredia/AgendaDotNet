using System.ComponentModel.DataAnnotations;

namespace APIAgenda.Models;

public class EventMessage
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(1000)]
    public string? MessageBody { get; set; }
    [Required]
    [Phone]
    [StringLength(15)]
    public string? MessageRecipient { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime MessageCreated { get; set; } = DateTime.Now;
    [Required]
    public int EventActionId { get; set; }
    [Required]
    public EventAction? EventAction { get; set; }
}
