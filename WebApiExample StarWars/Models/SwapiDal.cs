using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApiExample_StarWars.Models
{
    public class SwapiDal
    {

        public string GetAPIJSON(string endpoint, int Id)
        {
            string url = $"https://swapi.dev/api/{endpoint}/{Id}/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert the response into something usable
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string output = sr.ReadToEnd();
            return output;
        }

        public string GetAPIJSON(string endpoint)
        {
            string url = $"https://swapi.dev/api/{endpoint}/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert the response into something usable
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string output = sr.ReadToEnd();
            return output;
        }

        public Person GetPerson(int Id)
        {
            string endpoint = "people";
            string personData = GetAPIJSON(endpoint, Id);
            Person p  = JsonConvert.DeserializeObject<Person>(personData);
            return p;
        }

        public List<Person> GetPeople()
        {
            string endpoint = "people";
            string personData = GetAPIJSON(endpoint);
            PersonList p = JsonConvert.DeserializeObject<PersonList>(personData);
            
            return p.results.ToList();
        }

        //public Starship GetStarship(string endpoint, int Id)
        //{
        //    string starshipData = GetAPIJSON(endpoint, Id);
        //    Starship s = JsonConvert.DeserializeObject<Starship>(starshipData);

        //    return s;
        //}

        public Planet GetPlanet(int Id)
        {
            string endpoint = "planets";
            string planetData = GetAPIJSON(endpoint, Id);
            Planet p = JsonConvert.DeserializeObject<Planet>(planetData);
            return p;
        }


    }
}
