using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Treehouse.AspNetCore.Data;
using Treehouse.AspNetCore.Models;
using Treehouse.AspNetCore.ViewModels;

namespace Treehouse.AspNetCore.Controllers
{
    public class PlayersController : Controller
    {
        private readonly PlayerContext _context;

        public PlayersController(PlayerContext context)
        {
            _context = context;
        }

        // GET: Players
        public async Task<IActionResult> Index( string searchString, string teamString)
        {
            var teams = _context.Team2.Select(t => t);
            var teamNames = teams.Select(t => t.TeamName);
            var players = _context.Player.Select(p => p).Include(p => p.Team).OrderBy(p => p.Position).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                players = players.Where(p => p.Name.Contains(searchString)).ToList();
            }

            if (!String.IsNullOrEmpty(teamString))
            {
                
                players = players.Where(p => p.Team.TeamName == teamString).ToList();
 
            }


                var playerVM = new PlayerViewModel()
                {
                    SelectTeams = new SelectList(await teamNames.Distinct().ToListAsync()),
                    Players = players
                };
            //return View(await _context.Player.ToListAsync());
            return View(playerVM);

        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            PlayerViewModel playerViewModel = new PlayerViewModel()
            {
                Player = player
            };
            return View(playerViewModel);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            
            var teams = _context.Team2.ToList();
            //ViewBag.Teams = new SelectList(teams, "ID", "Team name");
            PlayerViewModel playerViewModel = new PlayerViewModel()
            {

                //Player = new Player(),


        };
            //playerViewModel.Teams = _context.Team.ToList();
            ViewBag.Title = "Create";
            return View(playerViewModel);
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Position,Skill,TeamId")] Player player)
        {

            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Position,Skill")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
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
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Player.FindAsync(id);
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }
    }
}
