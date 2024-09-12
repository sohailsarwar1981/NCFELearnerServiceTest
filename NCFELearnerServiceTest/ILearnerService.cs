using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCFELearnerServiceTest.BLL;

namespace NCFELearnerServiceTest
{
    internal interface ILearnerService
    {

        public Task<LearnerResponse> GetLearner(int learnerId, bool isLearnerArchvied);
    }
}
