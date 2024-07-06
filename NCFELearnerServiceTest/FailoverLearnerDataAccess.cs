namespace NCFELearnerServiceTest
{
    public class FailoverLearnerDataAccess
    {
        public  LearnerResponse GetLearnerById(int learnerId)
        {
            // retrieve learner from database using EF Core Identity
            Learner dbLearner = new Learner(learnerId,"FailoverLearnerName");
            // The datasourceEnum 2 is from failover data source
            return new LearnerResponse(2,dbLearner);
        }

        // The following new method was added to save the FailoverEntry in the DB
        public void SaveFailoverEntry(int learnerId)
        {
            FailoverEntry newFailoverEntry = new FailoverEntry(learnerId,DateTime.Now);
            //The code to save newFailoverEntry to the database using EF Core Identity will be added here.

        }


        public List<FailoverEntry> GetFailOverEntries()
        {
            // return all from fail entries from database
            return new List<FailoverEntry>();
        }

        public int GetNoFailOverEntriesInLastTenMins()
        {
            // Access the number of failed entries in last 10 minutes from a databse using EF Core Identity
            // The DB query is commented out and the following Mocked up code is used

            // SELECT count(*) as NoFailOverEntries
            // FROM[NewDB].[FO].[FailOverLearners]
            //where(CreatedDate >= DATEADD(mi, -10, getdate())) and(CreatedDate <= getdate())


            int NoFailOverEntries = new List<FailoverEntry>().Count();

            return NoFailOverEntries;
        }


    }
}
