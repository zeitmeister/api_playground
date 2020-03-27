using Treehouse.AspNetCore.ViewModels.AuthModel;

namespace Treehouse.AspNetCore.Repositories
{
    public class AuthModel : IBaseAuthModel
    {
        public bool IsAuth { get; set ; }
        public string Token { get; set; }
    }
}