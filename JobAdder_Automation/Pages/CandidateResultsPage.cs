using System;
using System.Collections.Generic;
using NLog;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;
using OpenQA.Selenium;
namespace JobAdder_Automation.Pages
{
    public class CandidateResultsPage : ResultsPageBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public CandidateResultsPage(DriverContext driverContext) : base(driverContext, "Candidate")
        {


        }
        public bool DefaultCandidateResultDisplayed()
        {
            if (GetGridRowCount() > 0)
                return true;
            else
                return false;

        }

        public bool FilterCandidatesUsingStanardFilters()
        {
            return FilterGridUsingStandardFilters();
        }

        public bool SavedSearchPerformedOnCandidates()
        {
            return InvokeSavedSearch();
        }

        public bool ClearSavedSearchOnCandidates()
        {
            return ClearSavedSearch();
        }

        public bool FilterCandidatesUsingColumnFilter(string columnName, string filtervalue)
        {
            return FilterResultsUsingColumnFilter("Candidate", columnName, filtervalue);
            
        }

        public bool ClearCandidateColumnFilter()
        {
            return ClearColumnFilter();
        }

        public bool AddCandidateRecordsToFolder()
        {
            return AddRecordsToFolder("Candidate");
        }
        public bool RemoveCandidateRecordsFromFolder()
        {
            return  RemoveRecordFromFolder("Candidate");
        }

        public bool PerformKeywordSearchOnCandidates(string keyword)
        {
            return PerformKeywordSearch("Candidate", keyword);
        }

        public bool InvokeQuickViewOnCandidates()
        {
            return InvokeQuickView();
        }

        public string  AddNotes()
        {
            string recordId= SelectaRecordFromResultsGrid("Candidate");
            InvokeHeaderMenu("Actions");
            ClickMenuItem("Add note");
            PopUpPage notesPopup = new PopUpPage(this.DriverContext);
            notesPopup.AddNote("Regression Testing");
            return recordId;
            
        }

        public bool LatestNotesDisplayedInQuickView(string recordId)
        {

            Driver.WaitUntilElementIsNoLongerFound(new ElementLocator(Locator.CssSelector, "ui-widget-overlay"),30);

            if (InvokeQuickViewOnRecord(recordId))
            {
                return CheckForLatestNotes();
            }
            return false;
           
        }

        public  bool  CandidateRecordStatusChanged()
        {
            return ChangeRecordStatus("Candidate");
        }

        public string SelectARecordFromCandidateResults()
        {
            return OpenARecordInViewMode("candidate");
        }
    }
}
