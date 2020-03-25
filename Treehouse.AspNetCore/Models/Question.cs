using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Treehouse.AspNetCore.ViewModels.AuthModel;

namespace Treehouse.AspNetCore.Models
{

    public class Questions
    {
        [JsonProperty("questions")]
        public Question[] QuestionsFromMongo { get; set; }
        public bool Auth { get; set; }
        public User user { get; set; }


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
        public void SetAuth(bool value)
        {
            throw new NotImplementedException();
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
