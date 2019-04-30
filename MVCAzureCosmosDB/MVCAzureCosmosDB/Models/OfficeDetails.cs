using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAzureCosmosDB.Models
{
    public class OfficeDetails
    {
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        public List<Person> RecruitingContacts { get; set; }
    }
}