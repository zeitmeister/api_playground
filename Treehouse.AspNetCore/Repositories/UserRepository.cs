using Newtonsoft.Json;
using RestApiWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Treehouse.AspNetCore.Controllers;
using Treehouse.AspNetCore.Models;
using Treehouse.AspNetCore.ViewModels.AuthModel;
using static Treehouse.AspNetCore.Models.UserModel;

namespace Treehouse.AspNetCore.Repositories
{
    public interface IUserRepository
    {
        public void SetAuth(bool auth);
        public bool Login(LoginUser user);
        public bool GetAuth();

        public bool Logout();
        public HttpResponseMessage GetQuestions();
        IQuestionDtoResult GetSpecificQuestion(string questionNr);
        UserModel GetProfile();
    }
    public class UserRepository : IUserRepository
    {
        private readonly IRestApiRequesterService _restApi;
        private readonly IBaseAuthModel _model;
        public BaseAuthModel Model { get; private set; }
        public UserRepository(IBaseAuthModel model, IRestApiRequesterService restApi)
        {
            _model = model;
            _restApi = restApi;
        }

        public bool GetAuth()
        {
            return _model.IsAuth;
        }

        public void SetAuth(bool auth)
        {
            _model.IsAuth = auth;
  
        }

        public HttpResponseMessage GetQuestions()
        {
            var response = _restApi.GetRequest("https://sleepy-falls-59530.herokuapp.com/questions", "Bearer", _model.Token);
            return response;
        }


        //TODO : set a dto with the username and password
        public bool Login(LoginUser model)
        {
            var response = _restApi.PostRequest("https://sleepy-falls-59530.herokuapp.com/questions/login", model);
            SetAuth(response.Result.IsSuccessStatusCode);
            if (GetAuth())
            {
                var responseBody = response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var loginResponseModel = JsonConvert.DeserializeObject<UserModel>(responseBody);
                _model.Token = loginResponseModel.Token;
                return GetAuth();
            }
            return GetAuth();
        }

        public bool Logout()
        {
            var response = _restApi.PostRequest("https://sleepy-falls-59530.herokuapp.com/questions/logout", null, "Bearer", _model.Token);
            if (response.Result.IsSuccessStatusCode)
            {
                var result = response.Result.Content.ReadAsStringAsync();
                _model.Token = _model.Token.Remove(0);
                return true;
            }
                
            return false;

        }

        public IQuestionDtoResult GetSpecificQuestion(string questionNr)
        {
            IQuestionDtoResult dtoResult = null;
            var response = _restApi.GetRequest($"https://sleepy-falls-59530.herokuapp.com/questions/{questionNr}", "Bearer", _model.Token);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                dtoResult = JsonConvert.DeserializeObject<QuestionDtoResult>(result);

                return dtoResult;
            }
            return dtoResult;
        }

        public UserModel GetProfile()
        {
            UserModel user = null;
            var response = _restApi.GetRequest($"https://sleepy-falls-59530.herokuapp.com/questions/user", "Bearer", _model.Token);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                user = JsonConvert.DeserializeObject<UserModel>(result);
            }
            return user;
        }
    }
}
