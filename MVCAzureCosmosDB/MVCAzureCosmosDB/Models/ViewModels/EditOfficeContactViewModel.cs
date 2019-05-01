using System;
using System.ComponentModel.DataAnnotations;

namespace MVCAzureCosmosDB.Models.ViewModels
{
    public class EditOfficeContactViewModel
    {
        [Required]
        public string PrevFirstName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}