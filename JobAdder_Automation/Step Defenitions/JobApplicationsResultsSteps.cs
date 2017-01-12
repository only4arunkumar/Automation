using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using System;
using TechTalk.SpecFlow;
using JobAdder_Automation.Pages;

namespace JobAdder_Automation
{
    [Binding]
    public class JobApplicationsResultsSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private JobApplicationsResultPage jobapplicationResultsPage;

        public JobApplicationsResultsSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.driverContext = scenarioContext["DriverContext"] as DriverContext;

        }

        [Given(@"I have navigated to placement results page")]
        public void GivenIHaveNavigatedToPlacementResultsPage()
        {
            JobAdderHeaderPage headerPage = new JobAdderHeaderPage(this.driverContext);
            headerPage.Navigate_To_Module("Job Applications");
            headerPage.Navigate_To_Respectivescreen(1);
            jobapplicationResultsPage = new JobApplicationsResultPage(this.driverContext);
     
        }
        
        [Then(@"the application allows me assign star rating for a JobApplication")]
        public void ThenTheApplicationAllowsMeAssignStarRatingForAJobApplication()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(jobapplicationResultsPage.AssignStarRatingForJobApplication()));
            
        }
    }
}
