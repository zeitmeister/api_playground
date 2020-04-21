using Newtonsoft.Json;
using RestApiWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Treehouse.AspNetCore.Models;
using Treehouse.AspNetCore.ViewModels.AuthModel;

namespace Treehouse.AspNetCore.Repositories
{
    public interface IUserRepository
    {
        public void SetAuth(bool auth);
        public void Login(bool auth, LoginResponseModel model);
        public bool GetAuth();

        public bool Logout();
        public HttpResponseMessage GetQuestions();
        IQuestionDtoResult GetSpecificQuestion(string questionNr);
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



        public void Login(bool auth, LoginResponseModel model)
        {
            SetAuth(auth);
            _model.Token = model.token;
        }

        public bool Logout()
        {
            var response = _restApi.PostRequest("https://sleepy-falls-59530.herokuapp.com/questions/logout", null, "Bearer", _model.Token);
            if (response.Result.IsSuccessStatusCode)
            {
                var result = response.Result.Content.ReadAsStringAsync();
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
    }
}
