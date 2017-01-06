using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using System;
using TechTalk.SpecFlow;
using JobAdder_Automation.Pages;


namespace JobAdder_Automation.Step_Defenitions
{
    [Binding]
    public class CandidateViewSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private CandidateViewPage canViewPage;
        private string recordId;

        public CandidateViewSteps(ScenarioContext scenarioContext)
        {
           
            this.scenarioContext = scenarioContext;
            this.driverContext = scenarioContext["DriverContext"] as DriverContext;
        }

        [Then(@"The application displays the  candidate record in view mode")]
        public void ThenTheApplicationDisplaysTheCandidateRecordInViewMode()
        {
           
            ScenarioContext.Current.TryGetValue("CanrecordIdView", out recordId);
            canViewPage = new CandidateViewPage(this.driverContext);
            canViewPage.CheckWhetherCandidateRecordDisplayedInViewMode(recordId);
            Verify.That(this.driverContext, () => Assert.IsTrue(canViewPage.CheckWhetherCandidateRecordDisplayedInViewMode(recordId)));
        }

     

        [When(@"I attempt to delete a Candidate record")]
        public void WhenIAttemptToDeleteACandidateRecord()
        {
            ScenarioContext.Current.TryGetValue("CanrecordIdView", out recordId);
            canViewPage = new CandidateViewPage(this.driverContext);
            canViewPage.DeleteCurrentCandidate(false);


        }

        [Then(@"The  appllication displays a warning message")]
        public void ThenTheAppllicationDisplaysAWarningMessage()
        {
            canViewPage = new CandidateViewPage(this.driverContext);
            Verify.That(this.driverContext, () => Assert.IsTrue(canViewPage.CheckWhetherDeleteConfirmationDisplayed()));
            
        }


    }
}
