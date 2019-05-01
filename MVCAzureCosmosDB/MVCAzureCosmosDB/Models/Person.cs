using Newtonsoft.Json;
using System;

namespace MVCAzureCosmosDB.Models
{
    public class Person
    {
        public Person()
        {
            this.PersonID = Guid.NewGuid();
        }

        [JsonProperty(PropertyName = "personID")]
        public Guid PersonID { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
    }
}