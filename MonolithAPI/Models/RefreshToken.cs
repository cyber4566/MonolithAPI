using System.ComponentModel.DataAnnotations;

namespace MonolithAPI.Models
{
    public class RefreshToken
    {




        [Key]
        public Guid refreshToken {  get; set; } = new Guid();
        [Required]
        public DateTime IssuedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime ExpireAt { get; set; } = DateTime.UtcNow.AddHours(5);

        [Required]
        public User User { get; set; }




    }
}
