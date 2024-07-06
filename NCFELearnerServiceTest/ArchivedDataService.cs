namespace NCFELearnerServiceTest
{
    public class ArchivedDataService
    {
        public LearnerResponse GetArchivedLearner(int learnerId)
        {
            // retrieve learner from archive data service
            Learner learner = new Learner(learnerId,"ArchivedLearnerName");

            // The parameter 3 indicates the learner data source is archived
            LearnerResponse learnerRes = new LearnerResponse(3, learner);
            return learnerRes;
        }
    }
}
