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
    }
}
