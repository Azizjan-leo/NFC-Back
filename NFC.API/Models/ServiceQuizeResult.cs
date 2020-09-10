using Newtonsoft.Json;
using NFC.API.Data;
using System.Collections.Generic;

namespace NFC.API.Models
{
    public class ServiceQuizeResult : IDeletable
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public virtual IList<ServiceQuizeAnswer> Answers { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class ServiceQuizeResultDTO
    {
        [JsonProperty(Required = Required.Always)]
        public int StationId { get; set; }
        public IList<AnswerDTO> Answers { get; set; }
    }
}
