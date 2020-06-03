using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExample_StarWars.Models
{
    public class PersonPlanet
    {
        public Person Person { get; set; }
        public Planet Planet { get; set; }

        public List<Person> People { get; set; }
    }
}
