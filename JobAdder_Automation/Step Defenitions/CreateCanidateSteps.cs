using JobAdder_Automation.Pages;
using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using System;
using TechTalk.SpecFlow;

namespace JobAdder_Automation.Step_Defenitions
{
    [Binding]
    public class CreateCanidateSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private CreateCanidatePage canCreatePage;
        private CandidateViewPage canViewPage;
        public CreateCanidateSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.driverContext = scenarioContext["DriverContext"] as DriverContext;
        }

        [Given(@"I have navigated to create candidate page")]
        public void GivenIHaveNavigatedToCreateCandidatePage()
        {
            JobAdderHeaderPage headerPage = new JobAdderHeaderPage(this.driverContext);
            headerPage.Navigate_To_Module("Candidates");
            headerPage.Navigate_To_Respectivescreen(6);
            canCreatePage = new CreateCanidatePage(this.driverContext);
        }
        
        [Given(@"I have manually entered the mandaory candidate fields")]
        public void GivenIHaveManuallyEnteredTheMandaoryCandidateFields()
        {
            canCreatePage.ManullyFillCandidateData();
        }
        
        [When(@"I press create button")]
        public void WhenIPressCreateButton()
        {
            canCreatePage.CreateAndSaveCandidateRecord();
        }
        
        [Then(@"the application creates the candidate record and display the result in view mode")]
        public void ThenTheApplicationCreatesTheCandidateRecordAndDisplayTheResultInViewMode()
        {
          
            Verify.That(this.driverContext, () => Assert.IsTrue(canCreatePage.CheckCanidateRecordDisplayed()));
           
           
        }

        [Given(@"I have uploaded a candidate resume to file-upload area")]
        public void GivenIHaveUploadedACandidateResumeToFile_UploadArea()
        {
            canCreatePage.UploadCandidateResume();

        }

        [Then(@"the application creates the candidate record from resume and display the result in view mode")]
        public void ThenTheApplicationCreatesTheCandidateRecordFromResumeAndDisplayTheResultInViewMode()
        {
            canViewPage = new CandidateViewPage(this.driverContext);
            Verify.That(this.driverContext, () => Assert.IsTrue(canViewPage.CheckWhetherCandidateRecordDisplayedInViewMode(canCreatePage.GetCandidateFirstName(), canCreatePage.GetCandidateLastName())));
            CandidateViewPage viewCandidate = new CandidateViewPage(this.driverContext);
            viewCandidate.DeleteCurrentCandidate(true);
        }




    }
}
