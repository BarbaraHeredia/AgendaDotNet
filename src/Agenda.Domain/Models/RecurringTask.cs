using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Domain.Models;

public class RecurringTask 
{ 
    [Key] 
    public int Id { get; set; } 
    [Required]
    [StringLength(100)] 
    public string SorceEvent { get; set; } 
    [Required]
    [StringLength(200)] 
    public string Title { get; set; } 
    [Required]
    [StringLength(1000)] 
    public string Description { get; set; } 
    [Required]
    [DataType(DataType.DateTime)] 
    public DateTime StartDateTime { get; set; } 
    [Required]
    [StringLength(50)] 
    public string Frequency { get; set; } 
    [DataType(DataType.DateTime)] 
    public DateTime? EndDateTime { get; set; } 
     
    public int? NumberOfOccurrences { get; set; } 
    [StringLength(500)] 
    public string Notes { get; set; } 
    [Required]
    [StringLength(50)] 
    public string Type { get; set; } 
}