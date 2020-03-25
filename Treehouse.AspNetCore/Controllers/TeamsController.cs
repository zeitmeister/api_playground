using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Treehouse.AspNetCore.Data;
using Treehouse.AspNetCore.Models;
using Treehouse.AspNetCore.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Treehouse.AspNetCore.LiveModels;
using Treehouse.AspNetCore.Services;
using static Treehouse.AspNetCore.Models.League;
using RestApiWrapper;

namespace Treehouse.AspNetCore.Controllers
{
    public class TeamsController : Controller
    {
        private readonly PlayerContext _context;
        private HttpClient _httpClient;
        private string _sorted;
        private static List<Team2> team2s;
        private ITimedUpdateService _timedUpdateService = null;
        private readonly IRestApiRequesterService _restApiRequestService;
        private readonly IUserService _userService;
        public TeamsController(PlayerContext context, IHttpClientFactory clientFactory, ITimedUpdateService timedUpdateService, IUserService userService)
        {
            _context = context;
            _httpClient = clientFactory.CreateClient("nhl");
            _sorted = "";
            team2s = _context.Team2.Select(t => t).Include(t => t.Division).ToList();
            _timedUpdateService = timedUpdateService;
            _userService = userService;
        }

     
        // GET: Teams
        public async Task<IActionResult> Index(string searchString, string teamDivision, string sortOrder, LoginResponseModel loginResponseModel)
        {
            
            _sorted = sortOrder;
            var divisionQuery = _context.Team2.OrderBy(t => t.Division.name).Select(t => t.Division.name).Distinct();
            var teams = _context.Team2.Select(t => t).Include(t => t.Division).ToList();
            //foreach (var team2 in teams)
            //{
            //    var request = new HttpRequestMessage(HttpMethod.Get, $"teams/{team2.Id}/stats");
            //    var response = await _httpClient.SendAsync(request);
            //    var responseStream = await response.Content.ReadAsStringAsync();
            //   // TeamStats.Rootobject test2 = new TeamStats.Rootobject();
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var stats = JsonConvert.DeserializeObject<TeamStats.Rootobject>(responseStream);
            //        team2.Points = stats.stats[0].splits[0].stat.pts.ToString();
            //        team2.GamesPlayed = stats.stats[0].splits[0].stat.gamesPlayed;
            //        //await _context.SaveChangesAsync();

            //    }
            //    //string pts = "";
            //    //int gamesPlayed = 0;
            //    //using (_httpClient)
            //    //{
            //    //    using (var nhlResponse = new HttpClient().GetAsync($"https://statsapi.web.nhl.com/api/v1/teams{team2.Id}/stats"))
            //    //    {
            //    //        string apiResponse = await nhlResponse.Result.Content.ReadAsStringAsync();
            //    //        var test = JsonConvert.DeserializeObject<TeamStats.Rootobject>(apiResponse);
            //    //        pts = test.stats[0].splits[0].stat.pts.ToString();
            //    //        gamesPlayed = test.stats[0].splits[0].stat.gamesPlayed;
            //    //    }
            //    //}

                
            //}
            teams = teams.OrderByDescending(t => t.Points).ToList();
            if (!string.IsNullOrEmpty(_sorted))
            {
                teams = teams.OrderByDescending(t => t.Points).ToList();
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                teams = teams.Where(t => t.name.Contains(searchString)).OrderByDescending(t => t.Points).ToList();
            }

            if (!string.IsNullOrEmpty(teamDivision))
            {
                teams = teams.Where(t => t.Division.name == teamDivision).OrderByDescending(t => t.Points).ToList();
            }

            var teamVM = new TeamViewModel()
            {
                Teamz = teams.ToList(),
                Divisions = new SelectList(await divisionQuery.Distinct().ToListAsync())

            };
            
            //if (loginResponseModel.token != null)
            //{
            //    var response = _restApiRequestService.GetRequest("https://sleepy-falls-59530.herokuapp.com/questions/user", "Bearer", loginResponseModel.token);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        return View(teamVM);
            //    }
            //}
            if (_userService.GetAuth())
            {
                return View(teamVM);
            }
            
            return RedirectToAction("UserLogin", "Users");
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stat = "";
            using(var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync($"https://statsapi.web.nhl.com/api/v1/teams/{id}/stats"))
                {
                    string apiResponse = await response.Result.Content.ReadAsStringAsync();
                    var stats = JObject.Parse(apiResponse);
                    stats.Remove("copyright");
                    var test = JsonConvert.DeserializeObject<TeamStats.Rootobject>(apiResponse).stats.ToList();
                    stat = test.FirstOrDefault().splits.FirstOrDefault().stat.pts.ToString();
                }
            }
            
            var team = await _context.Team2.Include(t => t.Division).Include(t => t.Venue)
                .FirstOrDefaultAsync(t => t.Id == id);
            //var team = await _context.Team2
            //    .FirstOrDefaultAsync(m => m.Id == id);
            
            if (team == null)
            {
                return NotFound();
            }
            TeamViewModel teamViewModel = new TeamViewModel()
            {
                Team2 = team,
                Points = stat
            };
            return View(teamViewModel);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamName,Venue")] Treehouse.AspNetCore.Models.League.Team2 team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var divisionQuery = _context.Team2.OrderBy(t => t.Division).Select(t => t.Division);
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team2.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            TeamViewModel teamViewModel = new TeamViewModel()
            {
                Team2 = team,
                Divisions = new SelectList(await divisionQuery.Distinct().ToListAsync())
            };
            return View(teamViewModel);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamName,Location,Division")] Treehouse.AspNetCore.Models.League.Team2 team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var divisionQuery = _context.Team2.OrderBy(t => t.Division).Select(t => t.Division);
            TeamViewModel teamViewModel = new TeamViewModel()
            {
                Team2 = await _context.Team2.FindAsync(id),
                Divisions = new SelectList(await divisionQuery.Distinct().ToListAsync())
            };       
            return View(teamViewModel);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Team2.FindAsync(id);
            _context.Team2.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Team2.Any(e => e.Id == id);
        }
    }
}
