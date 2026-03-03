using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MonolithAPI.Models
{
    
    public class User
    {

        [Key]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string HashedPassword { get; set; } = string.Empty;
        [Required]
        public Role Role { get; set; }


    }
}
