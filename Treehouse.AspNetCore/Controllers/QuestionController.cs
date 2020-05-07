using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Treehouse.AspNetCore.Models;
using Treehouse.AspNetCore.Services;

namespace Treehouse.AspNetCore.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IUserService _userService;
        private readonly IQuestionService _questionService;

        public QuestionController(IUserService userService, IQuestionService questionService)
        {
            _userService = userService;
            _questionService = questionService;
        }
        public async Task<IActionResult> Index()
        {
            if (_userService.GetAuth())
            {

                //TODO Fixa så att loginresponsemodel ej blir null när man trycker på user questions länken på sida.
                //Kanske jobba mer på att få en model att fungera som UserServicen kan använda. Där skulle man ju också kunna lagra token.
                var response = _questionService.GetQuestions();
                if (response.IsSuccessStatusCode)
                {
                    var questions = JsonConvert.DeserializeObject<Questions>(await response.Content.ReadAsStringAsync());
                    questions.IsAuth = _userService.GetAuth();
                    return View("~/Views/Questions/Index.cshtml", questions);
                }
                else
                {
                    return RedirectToAction("UserLogin","Users");
                }

            }
            // Hämtar användarna från ml-databasen
            return RedirectToAction("UserLogin", "Users");
        }

        public async Task<IActionResult> Question(string questionNr)
        {
            if (questionNr.IsNullOrEmpty())
            {
                return NotFound();
            }

            var questionModel = _questionService.GetSpecificQuestion(questionNr);
            questionModel.IsAuth = _userService.GetAuth();
            return View("~/Views/Questions/Question.cshtml", questionModel);
        }
    }
}