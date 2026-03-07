using MonolithAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MonolithAPI.DTO
{
    public class TokenResponseDTO
    {
        public string AccessToken { get; set; } = string.Empty;
        
        public RefreshToken RefreshToken { get; set; }



    }
}
