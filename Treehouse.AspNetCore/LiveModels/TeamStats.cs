﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Treehouse.AspNetCore.LiveModels
{
    public class TeamStats
    {

        public class Rootobject
        {
            public string copyright { get; set; }
            public IEnumerable<Stat> stats { get; set; }
        }

        public class Stat
        {
            public Type type { get; set; }
            public IEnumerable<Split> splits { get; set; }
        }

        public class Type
        {
            public string displayName { get; set; }
        }

        public class Split
        {
            public Stat1 stat { get; set; }
            public Team team { get; set; }
        }

        public class Stat1
        {
            public int gamesPlayed { get; set; }
            public object wins { get; set; }
            public object losses { get; set; }
            public object ot { get; set; }
            public object pts { get; set; }
            public string ptPctg { get; set; }
            public object goalsPerGame { get; set; }
            public object goalsAgainstPerGame { get; set; }
            public object evGGARatio { get; set; }
            public string powerPlayPercentage { get; set; }
            public object powerPlayGoals { get; set; }
            public object powerPlayGoalsAgainst { get; set; }
            public object powerPlayOpportunities { get; set; }
            public string penaltyKillPercentage { get; set; }
            public object shotsPerGame { get; set; }
            public object shotsAllowed { get; set; }
            public object winScoreFirst { get; set; }
            public object winOppScoreFirst { get; set; }
            public object winLeadFirstPer { get; set; }
            public object winLeadSecondPer { get; set; }
            public object winOutshootOpp { get; set; }
            public object winOutshotByOpp { get; set; }
            public object faceOffsTaken { get; set; }
            public object faceOffsWon { get; set; }
            public object faceOffsLost { get; set; }
            public string faceOffWinPercentage { get; set; }
            public float shootingPctg { get; set; }
            public float savePctg { get; set; }
            public string penaltyKillOpportunities { get; set; }
            public string savePctRank { get; set; }
            public string shootingPctRank { get; set; }
        }

        public class Team
        {
            public int id { get; set; }
            public string name { get; set; }
            public string link { get; set; }
        }

    }
}
