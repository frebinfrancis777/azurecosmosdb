using Newtonsoft.Json;

namespace MVCAzureCosmosDB.Models
{
    public class Office
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Firstname")]
        public string Firstname { get; set; }

        [JsonProperty(PropertyName = "Lastname")]
        public string Lastname { get; set; }

        [JsonProperty(PropertyName = "Middlename")]
        public string Middlename { get; set; }

        [JsonProperty(PropertyName = "State")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "School")]
        public string School { get; set; }

        [JsonProperty(PropertyName = "Schoolyear")]
        public string Schoolyear { get; set; }

        [JsonProperty(PropertyName = "Concentration")]
        public string Concentration { get; set; }

        [JsonProperty(PropertyName = "Degree")]
        public string Degree { get; set; }

        [JsonProperty(PropertyName = "Degreeconcentration")]
        public string Degreeconcentration { get; set; }

        [JsonProperty(PropertyName = "Major")]
        public string Major { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
    }
}