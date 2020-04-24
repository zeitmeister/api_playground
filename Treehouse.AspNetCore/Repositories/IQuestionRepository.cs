using Newtonsoft.Json;
using RestApiWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Treehouse.AspNetCore.Services;
using Treehouse.AspNetCore.ViewModels.AuthModel;

namespace Treehouse.AspNetCore.Repositories
{
    public interface IQuestionRepository
    {
        HttpResponseMessage GetQuestions();
        IQuestionDtoResult GetSpecificQuestion(string questionNr);
    }

    public class QuestionRespository : IQuestionRepository
    {
        private readonly IRestApiRequesterService _restApi;
        private readonly IBaseAuthModel _baseAuthModel;

        

        public QuestionRespository(IRestApiRequesterService restApi, IBaseAuthModel baseAuthModel)
        {
            _baseAuthModel = baseAuthModel;
            _restApi = restApi;
        }
        public HttpResponseMessage GetQuestions()
        {
            var response = _restApi.GetRequest("https://sleepy-falls-59530.herokuapp.com/questions", "Bearer", _baseAuthModel.Token);
            return response;
        }

        public IQuestionDtoResult GetSpecificQuestion(string questionNr)
        {
            IQuestionDtoResult dtoResult = null;
            var response = _restApi.GetRequest($"https://sleepy-falls-59530.herokuapp.com/questions/{questionNr}", "Bearer", _baseAuthModel.Token);
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
