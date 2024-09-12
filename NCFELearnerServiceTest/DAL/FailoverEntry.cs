using System;

namespace NCFELearnerServiceTest.DAL
{
    public class FailoverEntry
    {
        // A new learnerId field is added to store what learner ID request 
        // was failed. A constructor was added to set the values of member fields
        public int learnerId { get; set; }
        public DateTime DateTime { get; set; }

        public FailoverEntry(int _learnerId, DateTime _DateTime)
        {
            learnerId = _learnerId;
            DateTime = _DateTime;

        }
    }
}
