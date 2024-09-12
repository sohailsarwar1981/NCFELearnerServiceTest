using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCFELearnerServiceTest.DAL;

namespace NCFELearnerServiceTest.BLL
{
    public  class RepositoryLearner: IRepositoryLearner
    {
        public LearnerResponse GetArchivedLearner(int learnerId)
        {
            LearnerResponse archivedLearnerResponse = new ArchivedDataService().GetArchivedLearner(learnerId);  
            return archivedLearnerResponse;
        }

        public LearnerResponse GetFailOverLearner(int learnerId)
        {
            LearnerResponse failOverLearnerResponse = new FailoverLearnerDataAccess().GetLearnerById(learnerId);
             return failOverLearnerResponse;
        }

        public int GetFailOverEntriesInLastTenMinutes()
        {
            return new FailoverLearnerDataAccess().GetNoFailOverEntriesInLastTenMins();
        }

        public async Task<LearnerResponse> GetServiceLearner(int learnerId)
        {
            LearnerDataAccess learnerDA = new LearnerDataAccess();
            LearnerResponse failOverLearnerResponse = await  learnerDA.LoadLearner(learnerId);
            return failOverLearnerResponse;
        }


    }
}
