using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treehouse.AspNetCore.Models;
using static Treehouse.AspNetCore.Models.League;

namespace Treehouse.AspNetCore.ViewModels
{
    public class TeamViewModel
    {

        public Team2 Team2 { get; set; }

        public List<Team2> Teamz { get; set; }
        public SelectList Divisions { get; set; }
        public string SearchString { get; set; }
        public string TeamDivision { get; set; }

        public string Points { get; set; }
    }
}
