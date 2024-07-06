namespace NCFELearnerServiceTest
{
    public class LearnerResponse
    {

        // SourceStatus defines the data source of the learner record
        // Here the values can be either 1,2 or 3, where 1=Main3rdPartySource
        // 2= Failover data source, 3= Archived
        public int DataSourceEnum { get; set; }

        public Learner Learner { get; set; }

        // constructor to intialise learner response object
        public LearnerResponse(int _datasourceEnum, Learner learner) { 

            DataSourceEnum = _datasourceEnum;
            Learner = learner;  
        
        }
    }
}
