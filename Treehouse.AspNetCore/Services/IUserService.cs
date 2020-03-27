using System.Collections.Generic;
using System.Net.Http;
using Treehouse.AspNetCore.Models;
using Treehouse.AspNetCore.ViewModels.AuthModel;

namespace Treehouse.AspNetCore.Services
{
    public interface IUserService
    {
        bool GetAuth();
        void SetAuth(bool auth);
        void Login(bool auth, LoginResponseModel model);

        HttpResponseMessage GetQuestions();


    }

    public interface IMongoUserService
    {
        List<User> Get();
    }
}