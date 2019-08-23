using System.ComponentModel.DataAnnotations;

namespace restCore.Models
{
    public class Command
    {

        public int Id {get; set;}
        [Required]
        [StringLength(200)]
        public string Howto {get; set;}
        [Required]
        [StringLength(50)]
        public string Platform {get; set;}
        [Required]
        [StringLength(100)]
        public string Commandline {get; set;}
    }
}

