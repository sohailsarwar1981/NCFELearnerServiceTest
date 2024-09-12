using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCFELearnerServiceTest.BLL;
using NCFELearnerServiceTest.DAL;

namespace NCFELearnerServiceTest
{
    public class LearnerService: ILearnerService
    {
        private readonly IRepositoryLearner _repoLearner;

        public LearnerService(IRepositoryLearner repoLearner)
        {
            _repoLearner = repoLearner;
        }


        public async Task<LearnerResponse> GetLearner(int learnerId, bool isLearnerArchived)
        {


            LearnerResponse learnerResponse = null;

            // Check if the parameter isArchived is true then get Learner record
            // from Archived data source
            if (isLearnerArchived == true)
            {
                learnerResponse = _repoLearner.GetArchivedLearner(learnerId);
                return learnerResponse;
            }


            // Retrive the number of failover entries from the Failover repository in the last 10 mins
            int NoFailedRequests = _repoLearner.GetFailOverEntriesInLastTenMinutes();




            // if the failover requests is more than 100 in the last ten minutes then get the Learner
            // from the Failover data source
            // ELSE
            // get the learner from the main 3rd party web service

            // && (ConfigurationManager.AppSettings["IsFailoverModeEnabled"].ToLower() == "true")
            if (NoFailedRequests > 100 )
            {
                learnerResponse = _repoLearner.GetFailOverLearner(learnerId);
            }
            else
            {
                learnerResponse = await _repoLearner.GetServiceLearner(learnerId);
            }

               
                return learnerResponse;
            
        }


          




        }

    
}
