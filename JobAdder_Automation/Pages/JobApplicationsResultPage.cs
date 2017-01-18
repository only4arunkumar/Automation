using System;
using System.Collections.Generic;
using NLog;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
namespace JobAdder_Automation.Pages
{
    public class JobApplicationsResultPage :ResultsPageBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public JobApplicationsResultPage(DriverContext driverContext) : base(driverContext, "JobApplication")
        {       
           
        }
 
        public bool AssignStarRatingForJobApplication()
        {
            string recordId = SelectaRecordFromResultsGrid("JobApplication");
            return ChangeStarRatingForJobApplication(recordId);
        }

        private bool ChangeStarRatingForJobApplication(string recordId)
        {
            int initialRating = GetCurrentStartRating(recordId);
            ChangeStarRating(recordId);
            if (initialRating != GetCurrentStartRating(recordId))
            {
                return true;
            }
            return false;           
        }
    }
}
