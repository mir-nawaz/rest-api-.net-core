using System.ComponentModel.DataAnnotations;

namespace restCore.Models
{
    public class User
    {
        public int Id {get; set;}
        [Required]
        [StringLength(100)]
        public string Name {get; set;}
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {get; set;}
        [Required]
        [StringLength(15)]
        public string Password {get; set;}
    }
}

