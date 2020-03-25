using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Treehouse.AspNetCore.Services
{
    public interface ITimedUpdateService : IHostedService, IDisposable
    {

    }
}
