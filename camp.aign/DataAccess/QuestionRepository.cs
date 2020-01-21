using camp.aign.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace camp.aign.DataAccess
{
    public class QuestionRepository
    {
        public List<APIQuestion> GetAPIQuestions(int howMany = 1)
        {

            var client = new RestClient("https://opentdb.com/");
            
            var request = new RestRequest($"api.php?amount={howMany}&category=9&difficulty=easy&type=multiple", DataFormat.Json); 

            var response = client.Get(request);


            var apiQuestionList = JsonConvert.DeserializeObject<ApiResponse>(response.Content);

            return apiQuestionList.results;
        }
    }
}
