using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using System;
using TechTalk.SpecFlow;
using JobAdder_Automation.Pages;
namespace JobAdder_Automation.Step_Defenitions
{
    [Binding]
    public class CandidateResultsSteps
    {
        private readonly DriverContext driverContext;
        private CandidateResultsPage canResultsPage;

        public CandidateResultsSteps()
        {
            this.driverContext = ScenarioContext.Current["DriverContext"] as DriverContext;
        }
        [Given(@"I have navigated to Candidates results page")]
        public void GivenIHaveNavigatedToCandidatesResultsPage()
        {
            JobAdderHeaderPage headerPage = new JobAdderHeaderPage(this.driverContext);
            headerPage.Navigate_To_Module("Candidates");
            headerPage.Navigate_To_Respectivescreen(1);
            canResultsPage = new CandidateResultsPage(this.driverContext);

        }
        
        

        [Given(@"I have invoked my Saved Search")]
        public void GivenIHaveInvokedMySavedSearch()
        {

            ThenTheApplicationAllowsToInvokeMySavedSearch();
        }
                
     
        [Given(@"the application allows to filter results using '(.*)' and '(.*)'")]
        [Then(@"the application allows to filter results using (.*) and (.*)")]
        public void ThenTheApplicationAllowsToFilterResultsUsingAnd(string columnName, string filterString)
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(canResultsPage.FilterCandidatesUsingColumnFilter(columnName, filterString)));
            
        }

        [Given(@"I have selected a candidate record from the candidate results")]
        public void GivenIHaveSelectedACandidateRecordFromTheCandidateResults()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(canResultsPage.SelectARecordFromCandidateResults()));
        }

        [Given(@"I have added a note to a record")]
        public void GivenIHaveAddedANoteToARecord()
        {
            ScenarioContext.Current.Add("recordId", canResultsPage.AddNotes());
        }

        [Given(@"I have added a candidate record to  a folder")]
        public void GivenIHaveAddedACandidateRecordToAFolder()
        {
            ThenTheApplicationAllowsMeToAddRecordsIntoFolder();
        }

        [Then(@"the application displays the defualt results")]
        public void ThenTheApplicationDisplaysTheDefualtResults()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(canResultsPage.DefaultCandidateResultDisplayed()));

        }

        [Then(@"the application allows to filter the results")]
        public void ThenTheApplicationAllowsToFilterTheResults()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(canResultsPage.FilterCandidatesUsingStanardFilters()));

        }


        [Then(@"the application allows to invoke my SavedSearch")]
        public void ThenTheApplicationAllowsToInvokeMySavedSearch()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(canResultsPage.SavedSearchPerformedOnCandidates()));
        }
        [Then(@"the application allows to clear the SavedSearch")]
        public void ThenTheApplicationAllowsToClearTheSavedSearch()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(canResultsPage.ClearSavedSearchOnCandidates()));

        }

        [Then(@"the application allows me to clear column filter")]
        public void ThenTheApplicationAllowsMeToClearColumnFilter()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(canResultsPage.ClearCandidateColumnFilter()));
        }


        [Then(@"the application allows me to add records into folder")]
        public void ThenTheApplicationAllowsMeToAddRecordsIntoFolder()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(canResultsPage.AddCandidateRecordsToFolder()));
        }


        

        [Then(@"the application allows me to remove the record form folder")]
        public void ThenTheApplicationAllowsMeToRemoveTheRecordFormFolder()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(canResultsPage.RemoveCandidateRecordsFromFolder()));
        }

        [Then(@"the application allows me to perform ""(.*)"" Search")]
        public void ThenTheApplicationAllowsMeToPerformSearch(string keyWords)
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(canResultsPage.PerformKeywordSearchOnCandidates(keyWords)));
        }
        [Then(@"the  application  allows me to  invoke  Quickview")]
        public void ThenTheApplicationAllowsMeToInvokeQuickview()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(canResultsPage.InvokeQuickViewOnCandidates()));
        }

       

        [Then(@"the application displays the newly added notes in QuickView")]
        public void ThenTheApplicationDisplaysTheNewlyAddedNotesInQuickView()
        {
            string recordId;
            ScenarioContext.Current.TryGetValue("recordId", out recordId);
            Verify.That(this.driverContext, () => Assert.IsTrue(canResultsPage.LatestNotesDisplayedInQuickView(recordId)));
            ScenarioContext.Current.Remove("recordId");
        }

        [Then(@"the application allows me to change the status of a candidate record")]
        public void ThenTheApplicationAllowsMeToChangeTheStatusOfACandidateRecord()
        {
            Verify.That(this.driverContext, () => Assert.IsTrue(canResultsPage.CandidateRecordStatusChanged()));
        }


       

    }
}
