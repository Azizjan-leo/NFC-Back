using Microsoft.AspNetCore.Identity;
using NFC.API.Data;

namespace NFC.API.Models
{
    public class ApplicationUser : IdentityUser, IDeletable
    {
        public bool IsDeleted { get; set; }
    }
}
