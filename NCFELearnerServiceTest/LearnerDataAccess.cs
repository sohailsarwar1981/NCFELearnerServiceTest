
using Microsoft.Net.Http.Headers;
using System.Configuration;
using System.Net;
using Newtonsoft.Json; 

namespace NCFELearnerServiceTest
{
    public class LearnerDataAccess
    {
        public async Task<LearnerResponse> LoadLearner(int learnerId)
        {
            // retrieve learner from 3rd party webservice 
            // if the web service response is not successful or the web service is down
            // then this is recorded as a Failover Entry in the DB

            HttpClient client = new HttpClient();
            Learner learner = null;

            var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            ConfigurationManager.AppSettings["LearnerAPI"] + "/GetLearner" + learnerId)
            {
                Headers =
            {
                { HeaderNames.Accept, "application/json" },
                { HeaderNames.Authorization, "Bearer " + "jwt token here"  }
            }
            };

            FailoverLearnerDataAccess failoverLearnerDA = new FailoverLearnerDataAccess();

            try
            {

                var httpResponseMessage = await client.SendAsync(httpRequestMessage);


                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();

                    learner = JsonConvert.DeserializeObject<Learner>(contentStream);

                    // Mock up leaner from main source with name
                    learner = new Learner(learnerId, "ThirdPartyWebServiceLearner");
                }
                else
                {
                    failoverLearnerDA.SaveFailoverEntry(learnerId);
                }
            }
            catch (Exception ex)
            {
                // save as FailOverEntry
                failoverLearnerDA.SaveFailoverEntry(learnerId);
            }

            return new LearnerResponse(1, learner);
        }



    }
}
