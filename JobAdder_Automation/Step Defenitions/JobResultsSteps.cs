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
        private JobResultsPage jobResultsPage;
        public JobResultsSteps()
        {
            this.driverContext = ScenarioContext.Current["DriverContext"] as DriverContext;

        }
        [Given(@"I have navigated to Jobs results page")]
        public void GivenIHaveNavigatedToJobsResultsPage()
        {
            JobAdderHeaderPage headerPage = new JobAdderHeaderPage(this.driverContext);
            headerPage.Navigate_To_Module("Jobs");
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

    }
}
