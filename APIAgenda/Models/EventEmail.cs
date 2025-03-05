using System.ComponentModel.DataAnnotations;

namespace APIAgenda.Models;

public class EventEmail
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [StringLength(200)]
    public string? EmailMessage { get; set; }
    [Required]
    [StringLength(100)]
    public string? EmailSubject { get; set; }
    [Required]
    [StringLength(2000)]
    public string? EmailBody { get; set; }
    [Required]
    [EmailAddress]
    [StringLength (100)]
    public string? EmailRecipient { get; set; }
    [StringLength(500)]
    public string? EmailAttachments { get; set;}
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateTime { get; set; }
    [Required]
    public int EventActionId { get; set; }
    [Required]
    public EventAction? EventAction { get; set; }
          
}
