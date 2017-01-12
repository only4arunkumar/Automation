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
            try
            {
                IWebElement starRating = Driver.FindElement(By.CssSelector(string.Format("div[data-itemid='{0}']", recordId)));
                Driver.Actions().Build();
                Driver.Actions().ClickAndHold(starRating);
                Random rateSelected = new Random();
                Driver.Actions().MoveToElement(starRating.FindElement(By.CssSelector(string.Format("i:nth-child({0})", rateSelected.Next(1, 5)))));
                Driver.Actions().Release();
                Driver.Actions().Perform();
                return true;
            }catch(NoSuchElementException ex)
            {
                logger.Error("NoSuchElementException encuntered in ChangeStarRatingForJobApplication :{0}", ex.Message);
            }
            return false;
            
            

        }
    }
}
