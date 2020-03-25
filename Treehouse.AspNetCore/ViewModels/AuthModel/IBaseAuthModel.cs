namespace Treehouse.AspNetCore.ViewModels.AuthModel
{
    public interface IBaseAuthModel
    {
        bool IsAuth { get; set; }
        string Token { get; set; }
    }
}