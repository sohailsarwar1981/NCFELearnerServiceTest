using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCFELearnerServiceTest
{
    public class LearnerService: ILearnerService
    {

        
        public async Task<LearnerResponse> GetLearner(int learnerId, bool isLearnerArchived)
        {
           
            // Check if the parameter isArchived is true then get Learner record
            // from Archived data source
            if (isLearnerArchived == true)
            {        
                ArchivedDataService archivedDataService = new ArchivedDataService();
                return archivedDataService.GetArchivedLearner(learnerId);
            }


            // Retrive the number of failover entries from the Failover repository in the last 10 mins
            FailoverLearnerDataAccess failoverLearnerDA = new FailoverLearnerDataAccess();
            int NoFailedRequests = failoverLearnerDA.GetNoFailOverEntriesInLastTenMins();

               

            LearnerResponse learnerResponse = null;

            // if the failover requests is more than 100 in the last ten minutes then get the Learner
            // from the Failover data source
            // ELSE
            // get the learner from the main 3rd party web service

            if (NoFailedRequests > 100 && (ConfigurationManager.AppSettings["IsFailoverModeEnabled"].ToLower() == "true"))
            {
                learnerResponse = failoverLearnerDA.GetLearnerById(learnerId);
            }
            else
            {
                    LearnerDataAccess dataAccess = new LearnerDataAccess();
                    learnerResponse = await dataAccess.LoadLearner(learnerId);
            }

               
                return learnerResponse;
            
        }


          




        }

    
}
