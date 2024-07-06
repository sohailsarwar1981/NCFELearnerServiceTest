namespace NCFELearnerServiceTest
{
    public class Learner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Learner() { 
        }
        public Learner(int learnerId,string learnerName)
        {
            Id = learnerId;
            Name = learnerName;
        }
    }
}
