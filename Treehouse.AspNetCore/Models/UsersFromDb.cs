using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Treehouse.AspNetCore.Models
{
    public class UsersFromDb
    {

        public class Rootobject
        {
            public List<Class1> Property1 { get; set; }
        }

        public class Class1
        {
            public int Id { get; set; }
            public bool isVerified { get; set; }
            //public string[] answersVoted { get; set; }
            public string _id { get; set; }
            public string username { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public int __v { get; set; }
            public List<Token> tokens { get; set; }
        }

        public class Token
        {
            public string _id { get; set; }
            public string token { get; set; }
        }

    }
}
