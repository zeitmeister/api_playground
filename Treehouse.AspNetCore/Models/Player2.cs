using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Treehouse.AspNetCore.Models
{
    public class Player2
    {

        public class Rootobject
        {
            public int Id { get; set; }
            public ICollection<Roster> roster { get; set; }
            public string link { get; set; }
        }


        public class Roster
        {
            public int Id { get; set; }
            public Person person { get; set; }
            public string jerseyNumber { get; set; }
            public Position Position { get; set; }
        }

        public class Person
        {
            [Key] 
            public int Id { get; set; }

            [JsonProperty(PropertyName="id")]
            public int ApiNr { get; set; }
            public string fullName { get; set; }
            public string link { get; set; }
        }

        public class Position
        {
            public int Id { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string abbreviation { get; set; }
        }

    }
}
