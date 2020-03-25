using System.Collections.Generic;
using System.Net.Http;
using Treehouse.AspNetCore.Models;

namespace Treehouse.AspNetCore.Services
{
    public interface IUserService
    {
        bool GetAuth();
        void SetAuth(bool auth);

        HttpResponseMessage GetQuestions();

        void SetAuths(LoginResponseModel model);


    }

    public interface IMongoUserService
    {
        List<User> Get();
    }
}