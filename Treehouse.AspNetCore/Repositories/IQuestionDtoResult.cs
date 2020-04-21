using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treehouse.AspNetCore.Models;

namespace Treehouse.AspNetCore.Repositories
{
    public interface IQuestionDtoResult
    {
        public string Id { get; set; }


         string Text { get; set; }
         string UserId { get; set; }


         string Username { get; set; }


         DateTime CreatedAt { get; set; }
         Answer[] Answers { get; set; }
         int __v { get; set; }
    }

    public class QuestionDtoResult : IQuestionDtoResult
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public Answer[] Answers { get; set; }
        public int __v { get; set; }
    }


}
