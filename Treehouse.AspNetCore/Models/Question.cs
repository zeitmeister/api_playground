using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Treehouse.AspNetCore.Repositories;
using Treehouse.AspNetCore.ViewModels.AuthModel;

namespace Treehouse.AspNetCore.Models
{

    public class Questions : IBaseAuthModel
    {
        [JsonProperty("questions")]
        public Question[] QuestionsFromMongo { get; set; }
        public User user { get; set; }
        public bool IsAuth { get; set; }
        public string Token { get; set ; }
    }



    public class Question 
    {
        public string _id { get; set; }

        [DisplayName("Question")]
        public string text { get; set; }
        public string userId { get; set; }

        [DisplayName("Asked by")]
        public string username { get; set; }

        [DisplayName("Question asked at")]
        public DateTime createdAt { get; set; }
        public Answer[] answers { get; set; }
        public int __v { get; set; }


    }

    public class QuestionModel : IBaseAuthModel
    {
        private readonly IQuestionDtoResult _dto;
        public string _id => _dto.Id;

        [DisplayName("Question")]
        public string text => _dto.Text;
        public string userId => _dto.UserId;

        [DisplayName("Asked by")]
        public string username => _dto.Username;

        [DisplayName("Question asked at")]
        public DateTime createdAt => _dto.CreatedAt;
        public Answer[] answers => _dto.Answers;
        public int __v => _dto.__v;

        public bool IsAuth { get; set; }
        public string Token { get; set; }

        public QuestionModel(IQuestionDtoResult dto)
        {
            _dto = dto;
        }
    }

    public class Answer
    {
        public int votes { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string _id { get; set; }
        public string text { get; set; }
        public string answeredBy { get; set; }
    }

}
