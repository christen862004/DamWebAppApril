using Microsoft.AspNetCore.Identity;

namespace DamWebAppApril.Models
{
    public class AppliactionUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
