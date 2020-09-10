using NFC.API.Data;
using System.ComponentModel.DataAnnotations;

namespace NFC.API.Models
{
    public class ServiceQuizeQuestion : IDeletable
    {
        public int Id { get; set; }

        [StringLength(80, MinimumLength = 7)]
        [Required]
        public string Question { get; set; }

        public bool IsDeleted { get; set; }
    }
}
