using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Treehouse.AspNetCore.Models;
using static Treehouse.AspNetCore.Models.League;

namespace Treehouse.AspNetCore.Data
{
    public static class SeedData
    {
         
        public static async Task<List<Treehouse.AspNetCore.Models.League.Team2>> SeedWithTeams()
        {
            
            League1 league = new Treehouse.AspNetCore.Models.League.League1();
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://statsapi.web.nhl.com/api/v1/teams");
            var response = await httpClient.GetStringAsync(httpClient.BaseAddress);
            var test = Newtonsoft.Json.JsonConvert.DeserializeObject<Treehouse.AspNetCore.Models.League.League1>(response);
            var teams = test.Teams.ToList();

            List<Player2.Rootobject> _players = new List<Player2.Rootobject>();

            foreach (var team2 in teams)
            {
                team2.Roster = new List<Player>();
                using (var nhlResponse =
                    new HttpClient().GetAsync($"https://statsapi.web.nhl.com/api/v1/teams/{team2.Id}/roster"))
                {
                    string apiResponse = await nhlResponse.Result.Content.ReadAsStringAsync();
                    var players = JsonConvert.DeserializeObject<Player2.Rootobject>(apiResponse);
                    
                    foreach (var player in players.roster)
                    {
                        var playerToAdd = new Player
                        {
                            ApiNr = player.person.ApiNr,
                            Name = player.person.fullName,
                            Position = player.Position.name
                        };
                        team2.Roster.Add(playerToAdd);
                    }
                    
                    
                }


            }

            return teams;
        }



        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new PlayerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PlayerContext>>());
            using (context)
            {
                
                if (context.Team2.Any())
                {
                    return;
                }


                var teams = SeedData.SeedWithTeams().Result;
                
                context.Team2.AddRange(teams);
                
                context.Database.OpenConnection();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Team2 ON");
                    
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Team2 OFF");
                   
                }
                finally
                {
                    context.Database.CloseConnection();
                }

            }

            
        }
    }
}
