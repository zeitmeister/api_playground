using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treehouse.AspNetCore.ViewModels.AuthModel;

namespace Treehouse.AspNetCore.Models
{
    public class UserModel : IBaseAuthModel
    {
        public bool IsAuth { get ; set ; }
        public string Token { get; set; }

        public class Rootobject
        {
            public User User { get; set; }
        }

        public class User
        {
            public int Id { get; set; }

            [JsonProperty("isVerified")]
            public bool IsVerified { get; set; }

            [JsonProperty("answersVoted")]
            public string[] AnswersVoted { get; set; }

            [JsonProperty("_id")]
            public string UserMongoId { get; set; }

            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }
            public int __v { get; set; }

            [JsonProperty("tokens")]
            public List<UsedUserToken> UsedUserTokens { get; set; }
        }

        public class UsedUserToken
        {
            [JsonProperty("_id")]
            public string  UsedUserTokenId{ get; set; }


            [JsonProperty("token")]
            public string UsedUserTokenNr { get; set; }
        }

    }
}
