using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCAzureCosmosDB.Models.ViewModels
{
    public class EditOfficeContactViewModel
    {
        [Required]
        [DisplayName("Prev First Name")]
        public string PrevFirstName { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Phone Name")]
        public string Phone { get; set; }
    }
}