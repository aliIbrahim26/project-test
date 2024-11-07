using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PostLand_Api.Model
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
    }
}
