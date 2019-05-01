using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAzureCosmosDB.Models.ViewModels
{
    public class OfficeListViewModel
    {
        public string Id { get; set; }

        public Guid PersonID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Phone { get; set; }

        public string Middlename { get; set; }

        public string State { get; set; }

        public string Description { get; set; }
    }
}