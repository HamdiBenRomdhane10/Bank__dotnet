using Microsoft.AspNetCore.Identity;

namespace Bank.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
       
    }
}
