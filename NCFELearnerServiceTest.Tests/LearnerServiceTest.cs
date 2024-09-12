using Xunit;
using FluentAssertions;
using NCFELearnerServiceTest.DAL;
using NCFELearnerServiceTest.BLL;
namespace NCFELearnerServiceTest.Tests
{
    public class LearnerServiceTest
    {
        [Fact]
        public async Task TestLearnerServiceForFailoverLearner()
        {
            //Arrange object for the test
            LearnerResponse expected = new LearnerResponse(
                2,
                new Learner(
                    200, "FailoverLearnerName"
                )
                );

            //Act
            IRepositoryLearner IRepoLearner = new RepositoryLearner();
            var learnerService = new LearnerService(IRepoLearner);
            LearnerResponse result = await learnerService.GetLearner(200, false);

            //Assert
            result.Should().BeOfType<LearnerResponse>();
            result.Should().BeEquivalentTo(expected);
            result.Should().NotBeNull();

        }

        [Fact]
        public async Task TestLearnerServiceForArchivedLearner()
        {
            //Arrange object for the test
            var expected = new LearnerResponse(
                3,
                new Learner(
                    300, "ArchivedLearnerName"
                )
                );

            //Act
            IRepositoryLearner IRepoLearner = new RepositoryLearner();
            var learnerService = new LearnerService(IRepoLearner);
            var result = await learnerService.GetLearner(300, true);

            //Assert
            result.Should().BeOfType<LearnerResponse>();
            result.Should().BeEquivalentTo(expected);
            result.Should().NotBeNull();


        }

        // Please note that other unit tests should be written in the same way for
        // Third party learner and Failover data source
    }
}