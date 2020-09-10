using NFC.API.Data;
using System.ComponentModel.DataAnnotations;

namespace NFC.API.Models
{
    public class ServiceQuizeAnswer : IDeletable
    {
        public int Id { get; set; }

        [Required]
        public virtual ServiceQuizeQuestion Question{ get; set; }

        [Required]
        public bool Answer { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class AnswerDTO
    {
        public int QuestionID { get; set; }
        public bool Answer { get; set; }
    }
}
