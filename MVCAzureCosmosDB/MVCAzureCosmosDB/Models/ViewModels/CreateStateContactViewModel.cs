using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCAzureCosmosDB.Models.ViewModels
{
    public class CreateStateContactViewModel
    {
        public CreateStateContactViewModel()
        {
            this.States = new List<SelectListItem>();
        }

        [Required]
        [DisplayName("State")]
        public string State { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Phone")]
        public string Phone { get; set; }

        public IEnumerable<SelectListItem> States { get; set; }
    }
}