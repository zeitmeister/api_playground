﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Treehouse.AspNetCore.Models
{
    public class LoginResponseModel
    {
        public LoggedInUser user { get; set; }
        public string token { get; set; }
    }


    public class LoggedInUser
    {
        public bool isVerified { get; set; }
        public string[] answersVoted { get; set; }
        public string _id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int __v { get; set; }
    }



    
}
