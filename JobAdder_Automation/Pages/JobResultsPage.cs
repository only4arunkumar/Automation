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
    public class JobResultsPage: ResultsPageBase
    {
               

        public JobResultsPage(DriverContext driverContext) : base(driverContext, "JobOrder")
        {


        }

        public bool DefaultjobOrderResultDisplayed()
        {
            if (GetGridRowCount() > 0)
                return true;
            else
                return false;

        }

        public bool FilteJobsUsingStanardFilters()
        {
            return FilterGridUsingStandardFilters();
        }

        public bool SavedSearchPerformedOnJob()
        {
            return InvokeSavedSearch();
        }

        public bool ClearSavedSearchOnJobs()
        {
            return ClearSavedSearch();
        }

        public bool FilterJobsUsingColumnFilter(string columnName, string filtervalue)
        {
            return FilterResultsUsingColumnFilter("JobOrder", columnName, filtervalue);

        }

        public bool AddJobRecordsToFolder()
        {
            return AddRecordsToFolder("JobOrder");
        }

        public bool RemoveJobRecordsFromFolder()
        {
            return RemoveRecordFromFolder("JobOrder");
        }

        public bool InvokeQuickViewOnJobOrders()
        {
            return InvokeQuickView();
        }


        public string AddNotes()
        {
            string recordId = SelectaRecordFromResultsGrid("JobOrder");
            InvokeHeaderMenu("Actions");
            ClickMenuItem("Add note");
            PopUpPage notesPopup = new PopUpPage(this.DriverContext);
            notesPopup.AddNote("Regression Testing");
            return recordId;

        }

        public bool LatestNotesDisplayedInQuickView(string recordId)
        {
            if (InvokeQuickViewOnRecord(recordId))
            {
                return CheckForLatestNotes();
            }
            return false;

        }

    }
}
