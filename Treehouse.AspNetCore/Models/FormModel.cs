using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treehouse.AspNetCore.ViewModels.AuthModel;

namespace Treehouse.AspNetCore.Models
{
    public class FormModel : IBaseAuthModel
    {
        public string FirstName { get; set; }
        public bool IsAuth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Token { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
