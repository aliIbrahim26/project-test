using System.ComponentModel.DataAnnotations;

namespace PostLand_Api.Model
{
    public class RigsterModel
    {
       // [Required,MaxLength(50)]
        public string? UserName { get; set; }
       // [Required]
        public string? Password { get; set; }
        
       // [Required, MaxLength(50)]
        public string? Email { get; set; }
      //  [Required]
        public string? LastName { get; set; }
      //  [Required]
        public string? FirstName { get; set; }
    }
}
