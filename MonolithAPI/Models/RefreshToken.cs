using System.ComponentModel.DataAnnotations;

namespace MonolithAPI.Models
{
    public class RefreshToken
    {
        [Key]
        public Guid refreshToken {  get; set; }
        [Required]
        public DateTime IssuedAt { get; set; }
        [Required]
        public DateTime ExpireAt { get; set; }


    }
}
