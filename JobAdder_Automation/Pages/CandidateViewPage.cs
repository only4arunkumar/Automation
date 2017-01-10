using System;
using System.Collections.Generic;
using NLog;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;
using OpenQA.Selenium;
using JobAdder_Automation.Helpers;
using OpenQA.Selenium.Remote;
using System.IO;

namespace JobAdder_Automation.Pages
{
    public class CandidateViewPage : ProjectPageBase
    {

        public CandidateViewPage(DriverContext Drivercontext) : base(Drivercontext)
        {

        }
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        private ElementLocator candidateNameLink = new ElementLocator(Locator.CssSelector, ".quick-browse a");
             
        public bool CheckWhetherCandidateRecordDisplayedInViewMode(string firstName, string lastName)
        {
            return Driver.GetElement(candidateNameLink).Text.ToLowerInvariant().Contains(firstName.ToLowerInvariant()) && Driver.GetElement(candidateNameLink).Text.ToLowerInvariant().Contains(lastName.ToLowerInvariant()) ? true : false;

        }
        public bool CheckWhetherCandidateRecordDisplayedInViewMode(string recordId)
        {
            return Driver.Url.Contains(recordId);
        }
        public bool DeleteCurrentCandidate(bool confirmDelete)
        {
            try
            {
                ElementLocator ActionMenu = new ElementLocator(Locator.LinkText, "Actions");
                Driver.GetElement(ActionMenu).Click();
                Driver.WaitForAjax();
                ElementLocator DeleteMenuitem = new ElementLocator(Locator.LinkText, "Delete candidate");
                Driver.GetElement(DeleteMenuitem).Click();
                if(confirmDelete)
                {
                    ElementLocator ConfirmDelete = new ElementLocator(Locator.CssSelector, "button.critical");
                    Driver.GetElement(ConfirmDelete).Click();
                }
                
                return true;
            }catch(NoSuchElementException ex)
            {
                logger.Error("NoSuchElement exception  in DeleteCurrentCandidate:{0}", ex.Message);
                return false;
            }
            catch(TimeoutException ex)
            {
                logger.Error("Timeout exception in DeleteCurrentCandiatw:{0}", ex.Message);
                return false;
            }


        }
        public bool CheckWhetherDeleteConfirmationDisplayed()
        {
            try
            {
                ElementLocator ConfirmDelete = new ElementLocator(Locator.CssSelector, "button.critical");
                ElementLocator CloseConfirmation = new ElementLocator(Locator.ClassName, "ui-dialog-titlebar-close");
                bool confirmationDisplayStatus = Driver.GetElement(ConfirmDelete).Displayed;
                Driver.GetElement(CloseConfirmation).Click();
                return confirmationDisplayStatus;
            }
            catch (NoSuchElementException ex)
            {
                logger.Error("NoSuchElement exception  in CheckWhetherDeleteConfirmationDisplayed:{0}", ex.Message);
                return false;
            }
            catch (TimeoutException ex)
            {
                logger.Error("Timeout exception in CheckWhetherDeleteConfirmationDisplayed:{0}", ex.Message);
                return false;
            }

        }
    }
}
