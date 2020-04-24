using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Treehouse.AspNetCore.Models;
using Treehouse.AspNetCore.Repositories;
using Treehouse.AspNetCore.ViewModels.AuthModel;

namespace Treehouse.AspNetCore.Services
{
    public interface IQuestionService
    {
        public HttpResponseMessage GetQuestions();
        QuestionModel GetSpecificQuestion(string questionNr);
    }

    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public HttpResponseMessage GetQuestions()
        {
            return _questionRepository.GetQuestions();
        }

        public QuestionModel GetSpecificQuestion(string questionNr)
        {
            return new QuestionModel(_questionRepository.GetSpecificQuestion(questionNr));
        }
    }
}
