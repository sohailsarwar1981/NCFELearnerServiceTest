using Xunit;
using FluentAssertions;
namespace NCFELearnerServiceTest.Tests
{
    public class LearnerServiceTest
    {

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
             var learnerService = new LearnerService();
            var result = await learnerService.GetLearner(300, true);

            //Assert
            result.Should().BeOfType<LearnerResponse>();
            result.Should().BeEquivalentTo( expected );
            result.Should().NotBeNull();


        }

        // Please note that other unit tests should be written in the same way for
        // Third party learner and Failover data source
    }
}