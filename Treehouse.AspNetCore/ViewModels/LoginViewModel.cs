using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Treehouse.AspNetCore.Models;
using Treehouse.AspNetCore.ViewModels.AuthModel;

namespace Treehouse.AspNetCore.ViewModels
{
    public class LoginViewModel : IBaseAuthModel 
    {
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public string Token { get ; set; }
        public bool IsAuth { get; set; }

        public void SetAuth(bool value)
        {
            throw new NotImplementedException();
        }
    }
}
