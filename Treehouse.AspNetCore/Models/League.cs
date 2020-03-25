using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Treehouse.AspNetCore.Models
{
    public class League
    {

        public class League1
        {
            [JsonProperty(PropertyName = "teams")]
            public Team2[] Teams { get; set; }
        }

        public class Team2
        {
            [JsonProperty(PropertyName = "id")]
           // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [JsonProperty(PropertyName = "Name")]
            public string name { get; set; }

            [JsonProperty(PropertyName = "venue")]
            [ForeignKey("VenueId")]
            public Venue Venue { get; set; }

            [JsonProperty(PropertyName = "abbreviation")]
            public string Abbreviation { get; set; }

            [JsonProperty(PropertyName = "teamName")]
            public string TeamName { get; set; }

            [JsonProperty(PropertyName = "locationName")]
            public string LocationName { get; set; }

            [JsonProperty(PropertyName = "division")]
            public Division Division { get; set; }

            public string Points { get; set; }
            public int GamesPlayed { get; set; }

            public ICollection<Player> Roster { get; set; }


            //[JsonProperty(PropertyName = "conference")]
            //public Conference Conference { get; set; }

            //[JsonProperty(PropertyName = "franchise")]
            //public Franchise Franchise { get; set; }

            //public ICollection<Player> Players { get; set; }

        }

        public class Venue
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public string Id { get; set; }
            public string name { get; set; }
            public string link { get; set; }
            public string city { get; set; }
           
        }

        public class Timezone
        {
            public string id { get; set; }
            public int offset { get; set; }
            public string tz { get; set; }
        }

        public class Division
        {
            public int Id { get; set; }

            [JsonProperty(PropertyName = "id")]
            public int DivisionNumber { get; set; }
            public string name { get; set; }
            public string link { get; set; }
        }

        public class Conference
        {
            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }
            public string name { get; set; }
            public string link { get; set; }
        }

        public class Franchise
        {
            public int franchiseId { get; set; }
            public string teamName { get; set; }
            public string link { get; set; }
        }

    }
}
