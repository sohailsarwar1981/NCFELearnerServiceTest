// See https://aka.ms/new-console-template for more information
using NCFELearnerServiceTest.BLL;
using NCFELearnerServiceTest;


IRepositoryLearner IRepoLearner = new RepositoryLearner();
var learnerService = new LearnerService(IRepoLearner);
var result = learnerService.GetLearner(200, false);

Console.WriteLine("Hello, World!");


