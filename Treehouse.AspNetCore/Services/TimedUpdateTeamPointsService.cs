using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Treehouse.AspNetCore.Data;
using Treehouse.AspNetCore.LiveModels;

namespace Treehouse.AspNetCore.Services
{
   
    public class TimedUpdateTeamPointsService : ITimedUpdateService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private Timer _timer;
        public TimedUpdateTeamPointsService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PlayerContext>();
                foreach (var team2 in dbContext.Team2.ToList())
                {
                    using (var nhlResponse =
                        new HttpClient().GetAsync($"https://statsapi.web.nhl.com/api/v1/teams/{team2.Id}/stats"))
                    {
                        string apiResponse = await nhlResponse.Result.Content.ReadAsStringAsync();
                        var test = JsonConvert.DeserializeObject<TeamStats.Rootobject>(apiResponse);
                        team2.Points = test.stats.FirstOrDefault().splits.FirstOrDefault().stat.pts.ToString();
                        team2.GamesPlayed = test.stats.FirstOrDefault().splits.FirstOrDefault().stat.gamesPlayed;

                    }

                    Console.WriteLine("TESTAR!!");
                    await dbContext.SaveChangesAsync();

                }
            }
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
