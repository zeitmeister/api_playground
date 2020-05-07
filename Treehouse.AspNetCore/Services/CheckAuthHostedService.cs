using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RestApiWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Treehouse.AspNetCore.ViewModels.AuthModel;
using Treehouse.AspNetCore.Models;

namespace Treehouse.AspNetCore.Services
{
    public class CheckAuthHostedService : ICheckAuthHostedService
    {
        private readonly IRestApiRequesterService _apiService;
        private readonly IUserService _userService;
        private readonly IBaseAuthModel _model;
        private Timer _timer;

        public CheckAuthHostedService(IBaseAuthModel model, IRestApiRequesterService apiService, IUserService userService)
        {
            _model = model;
            _apiService = apiService;
            _userService = userService;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));

            return Task.CompletedTask; 
        }

        private async void DoWork(object state)
        {
            using (var client = new HttpClient())
            {
                var response = _apiService.GetRequest("https://sleepy-falls-59530.herokuapp.com/questions/user", "Bearer", _model.Token);
                if (response.IsSuccessStatusCode)
                {
                    var user = JsonConvert.DeserializeObject<AuthenticatedUser>(response.Content.ReadAsStringAsync().Result);
                    _userService.SetAuth(true);

                } else
                {
                    _userService.SetAuth(false);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
    public interface ICheckAuthHostedService : IHostedService
    {
    }
}
