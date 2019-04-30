using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCAzureCosmosDB.Models.ViewModels
{
    public class CreateOfficeViewModel
    {
        public CreateOfficeViewModel()
        {
            States = new List<SelectListItem>();

            List<int> yearsList = new List<int>();
            for (int year = DateTime.Now.Year; year >= 1950; year--)
            {
                yearsList.Add(year);
            }

            Years = new SelectList(yearsList);
        }

        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "Firstname")]
        [Required]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [JsonProperty(PropertyName = "Lastname")]
        [Required]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [JsonProperty(PropertyName = "Middlename")]
        [Required]
        [Display(Name = "Middle Name")]
        public string Middlename { get; set; }

        [JsonProperty(PropertyName = "State")]
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "School")]
        [Required]
        [Display(Name = "School")]
        public string School { get; set; }

        [JsonProperty(PropertyName = "Schoolyear")]
        [Required]
        [Display(Name = "Year")]
        public string Schoolyear { get; set; }

        [JsonProperty(PropertyName = "Concentration")]
        [Required]
        [Display(Name = "Concentration")]
        public string Concentration { get; set; }

        [JsonProperty(PropertyName = "Degree")]
        [Required]
        [Display(Name = "Degree")]
        public string Degree { get; set; }

        [JsonProperty(PropertyName = "Degreeconcentration")]
        [Required]
        [Display(Name = "Concentration")]
        public string Degreeconcentration { get; set; }

        [JsonProperty(PropertyName = "Major")]
        [Required]
        [Display(Name = "Major")]
        public string Major { get; set; }

        [JsonProperty(PropertyName = "Description")]
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public bool AddMoreRecord { get; set; }

        public IEnumerable<SelectListItem> Years { get; set; }

        public IEnumerable<SelectListItem> States { get; set; }
    }
}