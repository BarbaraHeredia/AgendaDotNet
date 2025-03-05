using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APIAgenda.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Events = new Collection<Event>();
        }

        [Required]
        [StringLength(100)]
        public override string? UserName { get; set; }

        [Required]
        [StringLength(200)]
        public string? UserUrl { get; set; }

        public ICollection<Event>? Events { get; set; }
    }
}
