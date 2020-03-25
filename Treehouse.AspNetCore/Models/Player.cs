using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Treehouse.AspNetCore.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        public int ApiNr { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public int Skill { get; set; }

        public int TeamId { get; set; }
        public Treehouse.AspNetCore.Models.League.Team2 Team { get; set; }


    }
}
