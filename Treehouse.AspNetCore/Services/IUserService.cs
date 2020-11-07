using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Treehouse.AspNetCore.Controllers;
using Treehouse.AspNetCore.Models;
using Treehouse.AspNetCore.ViewModels.AuthModel;
using static Treehouse.AspNetCore.Models.UserModel;

namespace Treehouse.AspNetCore.Services
{
    public interface IUserService
    {
        bool GetAuth();
        void SetAuth(bool auth);
        bool Login(LoginUser user);
        bool Logout();
        UserModel GetProfile();
    }


}