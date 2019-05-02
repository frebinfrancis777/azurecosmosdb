using Newtonsoft.Json;
using System;

namespace MVCAzureCosmosDB.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
    }
}