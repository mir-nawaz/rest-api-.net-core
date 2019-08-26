using System.ComponentModel.DataAnnotations;

namespace restCore.Models
{
    public class JwtToken
    {
        public int Id {get; set;}
        [Required]
        [StringLength(100)]
        public string Issuer {get; set;}
        [Required]
        public int Expires {get; set;}
        [Required]
        [StringLength(32)]
        public string Token {get; set;}
        [Required]
        public User User {get; set;}
    }
}

