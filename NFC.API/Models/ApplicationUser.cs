using Microsoft.AspNetCore.Identity;
using static NFC.API.Data.ApplicationDbContext;

namespace NFC.API.Models
{
    public class ApplicationUser : IdentityUser, IDeletable
    {
        public bool IsDeleted { get; set; }
    }
}
