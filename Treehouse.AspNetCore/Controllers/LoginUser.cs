using Treehouse.AspNetCore.ViewModels;

namespace Treehouse.AspNetCore.Controllers
{
    public class LoginUser
    {
        private readonly LoginViewModel _loginViewModel;
        public string email => _loginViewModel.Email;
        public string password => _loginViewModel.Password;
        public LoginUser(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }
    }
}