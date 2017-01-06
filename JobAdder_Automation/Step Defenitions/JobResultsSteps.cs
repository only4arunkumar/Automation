using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using System;
using TechTalk.SpecFlow;
using JobAdder_Automation.Pages;
namespace JobAdder_Automation.Step_Defenitions
{
    [Binding]
    public class JobResultsSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private JobResultsPage jobResultsPage;
        public JobResultsSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.driverContext = scenarioContext["DriverContext"] as DriverContext;

        }
        [Given(@"I have navigated to Jobs results page")]
        public void GivenIHaveNavigatedToJobsResultsPage()
        {
            JobAdderHeaderPage headerPage = new JobAdderHeaderPage(this.driverContext);
            headerPage.Navigate_To_Module("Jobs");
            headerPage.Navigate_To_Respectivescreen(1);
            jobResultsPage = new JobResultsPage(this.driverContext);
        }
        
        [Then(@"the application displays the defualt Job results")]
        public void ThenTheApplicationDisplaysTheDefualtJobResults()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(jobResultsPage.DefaultjobOrderResultDisplayed()));
        }

        [Then(@"the application allows to filter Joborder  results")]
        public void ThenTheApplicationAllowsToFilterJoborderResults()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(jobResultsPage.FilteJobsUsingStanardFilters()));
        }

        [Then(@"the application allows to invoke my SavedSearch on Jobs records")]
        public void ThenTheApplicationAllowsToInvokeMySavedSearchOnJobsRecords()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(jobResultsPage.SavedSearchPerformedOnJob()));
        }

        [Given(@"I have invoked my Saved Search  on Job records")]
        public void GivenIHaveInvokedMySavedSearchOnJobRecords()
        {
            ThenTheApplicationAllowsToInvokeMySavedSearchOnJobsRecords();
        }

        [Then(@"the application allows to clear the SavedSearch on Jobs records")]
        public void ThenTheApplicationAllowsToClearTheSavedSearchOnJobsRecords()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(jobResultsPage.ClearSavedSearchOnJobs()));
        }

       

        [Then(@"the application allows to filter Job results using '(.*)' and '(.*)'")]
        public void ThenTheApplicationAllowsToFilterJobResultsUsingAnd(string columnName, string filterText)
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(jobResultsPage.FilterJobsUsingColumnFilter(columnName, filterText)));
        }

        [Given(@"I have added a Job record to  a folder")]
        [Then(@"the application allows me to add Job records into folder")]
        public void ThenTheApplicationAllowsMeToAddJobRecordsIntoFolder()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(jobResultsPage.AddJobRecordsToFolder()));
        }

    
        [Then(@"the application allows me to remove the Job record form folder")]
        public void ThenTheApplicationAllowsMeToRemoveTheJobRecordFormFolder()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(jobResultsPage.RemoveJobRecordsFromFolder()));
        }

        [Then(@"the  application  allows me to  invoke  Quickview  from Job records")]
        public void ThenTheApplicationAllowsMeToInvokeQuickviewFromJobRecords()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(jobResultsPage.InvokeQuickViewOnJobOrders()));
        }

        [Given(@"I have added a note to a Job record")]
        public void GivenIHaveAddedANoteToAJobRecord()
        {
            ScenarioContext.Current.Add("recordJobId", jobResultsPage.AddNotes());
        }

        [Then(@"the application displays the newly added notes in Jobs QuickView")]
        public void ThenTheApplicationDisplaysTheNewlyAddedNotesInJobsQuickView()
        {
            string recordId;
            ScenarioContext.Current.TryGetValue("recordJobId", out recordId);
            Verify.That(this.driverContext, () => Assert.IsTrue(jobResultsPage.LatestNotesDisplayedInQuickView(recordId)));
        }

        [Then(@"the application allows be to chage the status of the Job record")]
        public void ThenTheApplicationAllowsBeToChageTheStatusOfTheJobRecord()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(jobResultsPage.JobRecordStatusChanged()));
        }




    }
}
