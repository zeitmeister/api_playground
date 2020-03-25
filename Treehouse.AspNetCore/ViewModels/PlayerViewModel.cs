using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treehouse.AspNetCore.Models;

namespace Treehouse.AspNetCore.ViewModels
{
    public class PlayerViewModel
    {
        public Player Player { get; set; }
        public List<Player> Players { get; set; }
        public string TeamString { get; set; }
        public int TeamId { get; set; }


        public SelectList SelectTeams { get; set; }
    }
}
