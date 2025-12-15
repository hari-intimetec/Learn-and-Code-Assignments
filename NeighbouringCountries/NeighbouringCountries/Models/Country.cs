using System.Collections.Generic;
namespace NeighbouringCountries.Models
{
        public class Country
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public List<string> AdjacentCountries { get; set; }
        }
}
