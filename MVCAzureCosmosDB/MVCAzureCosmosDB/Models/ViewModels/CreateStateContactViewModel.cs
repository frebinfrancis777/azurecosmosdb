using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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
        public string State { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        public IEnumerable<SelectListItem> States { get; set; }
    }
}