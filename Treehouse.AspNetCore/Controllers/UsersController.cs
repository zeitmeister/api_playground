using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestApiWrapper;
using Treehouse.AspNetCore.Data;
using Treehouse.AspNetCore.Models;
using Treehouse.AspNetCore.Services;
using Treehouse.AspNetCore.ViewModels;

namespace Treehouse.AspNetCore.Controllers
{
    public class UsersController : Controller
    {
        private readonly PlayerContext _context;
        private readonly IUserService _userService;
        private readonly IRestApiRequesterService _restApiRequester;
        private HttpClient _httpClient;
        public UsersController(PlayerContext context, IUserService userService, IRestApiRequesterService restApiRequster)
        {
            _context = context;
            _userService = userService;
            _restApiRequester = restApiRequster;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            if (_userService.GetAuth())
            {

                //TODO Fixa så att loginresponsemodel ej blir null när man trycker på user questions länken på sida.
                //Kanske jobba mer på att få en model att fungera som UserServicen kan använda. Där skulle man ju också kunna lagra token.
                var response = _userService.GetQuestions();
                if (response.IsSuccessStatusCode)
                {
                    var questions = JsonConvert.DeserializeObject<Questions>(await response.Content.ReadAsStringAsync());
                    questions.IsAuth = _userService.GetAuth();
                    return View(questions);
                }
                else
                {
                    return RedirectToAction("UserLogin");
                }

            }
            // Hämtar användarna från ml-databasen
            return RedirectToAction("UserLogin");

        }


        public async Task<IActionResult> UserLogin()
        {
            LoginViewModel loginView = new LoginViewModel();
            return View(loginView);
        }

        public async Task<IActionResult> LogOut()
        {
            _userService.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginViewModel user)
        {
            var response = await _restApiRequester.PostRequest("https://sleepy-falls-59530.herokuapp.com/questions/login", user);

            var responseBody = await response.Content.ReadAsStringAsync();

            var loginResponseModel = JsonConvert.DeserializeObject<LoginResponseModel>(responseBody);

            if (response.IsSuccessStatusCode)
            {
                _userService.Login(true, loginResponseModel);
                return RedirectToAction("Index");
            }

            return NotFound();

        }

        public async Task<IActionResult> Question(string questionNr)
        {
            if (questionNr.IsNullOrEmpty())
            {
                return NotFound();
            }

            var questionModel = _userService.GetSpecificQuestion(questionNr);
            questionModel.IsAuth = _userService.GetAuth();
            return View("~/Views/Questions/Question.cshtml", questionModel);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,isVerified,MongoNr,username,email,password,__v")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,isVerified,MongoNr,username,email,password,__v")] User user)
        {
            if (id.ToString() != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id.ToString()))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.Id == id.ToString());
        }
    }
}
