global using Xunit;
using NCFELearnerServiceTest.Tests;

LearnerServiceTest learnerServiceTest = new LearnerServiceTest();
await learnerServiceTest.TestLearnerServiceForArchivedLearner();