using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Agenda.Domain.Models;
[Table("Events")]
public class Event
{
    public Event()
    {
        EventActions = new Collection<EventAction>();
    }
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string? EventName { get; set; }
    [Required, StringLength(500)]
    public string? EventDescription { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime? EventDateStart { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime? EventDateEnd { get; set; }
    [Required]
    [StringLength(450)]
    public string UserId { get; set; }
    [Required]
    
    public User? User { get; set; }
    [JsonIgnore]
    public ICollection<EventAction>? EventActions { get; set; }
}
