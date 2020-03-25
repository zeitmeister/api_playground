using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Treehouse.AspNetCore.Models;
using Treehouse.AspNetCore.ViewModels.AuthModel;

namespace Treehouse.AspNetCore.ViewModels
{
    public class LoginViewModel 
    {
        public string email { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }

        public bool IsAuth => default;

        public void SetAuth(bool value)
        {
            throw new NotImplementedException();
        }
    }
}
