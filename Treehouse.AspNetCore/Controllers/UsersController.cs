﻿using System;
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
using static Treehouse.AspNetCore.Models.UserModel;

namespace Treehouse.AspNetCore.Controllers
{
    public class UsersController : Controller
    {
        private readonly PlayerContext _context;
        private readonly IUserService _userService;
        private readonly IRestApiRequesterService _restApiRequester;
        public UsersController(PlayerContext context, IUserService userService, IRestApiRequesterService restApiRequster)
        {
            _context = context;
            _userService = userService;
            _restApiRequester = restApiRequster;
        }

        // GET: Users


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
            var loginUser = new LoginUser(user);
            if (_userService.Login(loginUser))
                return RedirectToAction("Index", "Question");
            
            return BadRequest();

        }

        [HttpGet]

        public async Task<IActionResult> Profile()
        {
            var user = _userService.GetProfile();
            if (user != null)
            {
                user.IsAuth = _userService.GetAuth();
                
                return View("~/Views/Users/User.cshtml", user);

            } else
            {
                return RedirectToAction("Index", "Question");
            }
        }

     

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var user = await _context.User
            //    .FirstOrDefaultAsync(m => m.Id == id.ToString());
            //if (user == null)
            //{
            //    return NotFound();
            //}

            return View();
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
        public async Task<IActionResult> Create([Bind("Id,isVerified,MongoNr,username,email,password,__v")] UserModel user)
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

            //var user = await _context.User.FindAsync(id);
            //if (user == null)
            //{
            //    return NotFound();
            //}
            return View();
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,isVerified,MongoNr,username,email,password,__v")] User user)
        {
            if (id.ToString() != user.Id.ToString())
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

                        throw;

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

            //var user = await _context.User
            //    .FirstOrDefaultAsync(m => m.Id == id.ToString());
            //if (user == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var user = await _context.User.FindAsync(id);
            //_context.User.Remove(user);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool UserExists(string id)
        //{
        //    return _context.User.Any(e => e.Id == id.ToString());
        //}
    }
}
