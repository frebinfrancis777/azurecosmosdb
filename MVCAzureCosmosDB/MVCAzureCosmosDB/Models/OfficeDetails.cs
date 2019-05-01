using Newtonsoft.Json;
using System.Collections.Generic;

namespace MVCAzureCosmosDB.Models
{
    public class OfficeDetails
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty("recruitingContacts")]
        public List<Person> RecruitingContacts { get; set; }
    }
}