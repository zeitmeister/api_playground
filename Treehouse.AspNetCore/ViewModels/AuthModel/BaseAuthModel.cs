using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Treehouse.AspNetCore.ViewModels.AuthModel
{
    public class BaseAuthModel : IBaseAuthModel
    {

        public bool IsAuth { get;  set; }

        public string Token { get; set; }


    }
}
