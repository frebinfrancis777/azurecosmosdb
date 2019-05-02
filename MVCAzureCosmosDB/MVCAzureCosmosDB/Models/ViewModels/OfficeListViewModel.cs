using System.ComponentModel;

namespace MVCAzureCosmosDB.Models.ViewModels
{
    public class OfficeListViewModel
    {
        public string Id { get; set; }

        [DisplayName("First Name")]
        public string Firstname { get; set; }

        [DisplayName("Last Name")]
        public string Lastname { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }

        [DisplayName("Middle Name")]
        public string Middlename { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }
    }
}