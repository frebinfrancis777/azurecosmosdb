using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAzureCosmosDB.Services
{
    public class StateAPIService
    {
        public static List<string> GetStates()
        {
            // TO-DO API logic here which returns list of states in string list

            return new List<string>() { "Newyork", "California", "Texas" };
        }
    }
}