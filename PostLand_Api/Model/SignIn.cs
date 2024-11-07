using System.ComponentModel.DataAnnotations;

namespace PostLand_Api.Model
{
    public class SignIn
    {
        [Required,MaxLength(30)]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}
