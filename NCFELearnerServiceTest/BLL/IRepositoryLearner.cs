using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCFELearnerServiceTest.BLL
{
   public interface IRepositoryLearner
    {

        public LearnerResponse GetArchivedLearner(int learnerId);
        public LearnerResponse GetFailOverLearner(int learnerId);
        public int GetFailOverEntriesInLastTenMinutes();
        public Task<LearnerResponse> GetServiceLearner(int learnerId);

    }
}
