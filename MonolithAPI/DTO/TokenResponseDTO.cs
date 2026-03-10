using MonolithAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MonolithAPI.DTO
{
    public class TokenResponseDTO
    {
        public string AccessToken { get; set; } = string.Empty;
        
        public Guid RefreshToken { get; set; }



    }
}
