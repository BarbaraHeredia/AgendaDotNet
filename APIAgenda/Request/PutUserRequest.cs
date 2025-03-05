using System.ComponentModel.DataAnnotations;

namespace APIAgenda.Request;

public class PutUserRequest
{
    [Required]
    public string Id { get; set; }
    [Required]
    [StringLength(100)]
    public string UserName { get; set; }
    [Required]
    [StringLength(200)]
    public string UserUrl { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }
}
