using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiExample_StarWars.Models;

namespace WebApiExample_StarWars.Controllers
{
    public class HomeController : Controller
    {
       private readonly SwapiDal SP = new SwapiDal();

        public IActionResult Index()
        {
            PersonPlanet p = new PersonPlanet();
            p.People = SP.GetPeople();
          return View(p);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PersonSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonSearch(int Id)
        {
            //We want to use the DAL to search people by Id
            PersonPlanet p = new PersonPlanet();
               p.Person = SP.GetPerson(Id);
            return View("Index", p);
        }

        //public IActionResult StarshipSearch()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult StarshipSearch(int Id)
        //{
        //    Starship s = SP.GetStarship("starships", Id);
        //    return View(s);
        //}

        public IActionResult PlanetSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlanetSearch(int Id)
        {
            PersonPlanet P = new PersonPlanet();
                P.Planet = SP.GetPlanet(Id);
            return View("Index", P);
        }

        //public IActionResult PersonPlanetSearch()
        //{
        //    return View();
        //}
        //public IActionResult PersonPlanetSearch(int Id)
        //{
        //    PersonPlanet pp = new PersonPlanet();
        //    pp.Person = SP.GetPerson(Id);
        //    pp.Planet = SP.GetPlanet(Id);
        //    return View("Index", pp);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
