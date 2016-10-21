using System;
using System.Collections.Generic;
using NLog;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Objectivity.Test.Automation.Common.WebElements;
using System.Linq;


namespace JobAdder_Automation.Pages
{
    public class PopUpPage:ProjectPageBase
    {
        public PopUpPage(DriverContext driverContext):base(driverContext)
        {

        }
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public bool SelectTab(string tabName)
        {
            try
            {
                ElementLocator tabSelector = new ElementLocator(Locator.ClassName, tabName);
                IWebElement curTab = Driver.GetElement(tabSelector);
                curTab.Click();
                Driver.WaitForAjax();
                if(curTab.GetAttribute("class").Contains("active"))
                {
                    return true;
                }
               

            }
            catch (TimeoutException ex)
            {

                logger.Error("Error encountered  in SelectTab:{0}", ex.Message);
            }
            return false;
        }

        public  string GetLatestNoteText()
        {
            try
            {
                ElementLocator latestNotes = new ElementLocator(Locator.CssSelector, ".note div .content");
                IWebElement notes = Driver.GetElement(latestNotes);
                return notes.GetTextContent();

            }catch(TimeoutException ex)
            {
                logger.Error("Error occured when fetching latest notes:{0}", ex.Message);
            }
            return string.Empty;
        }

        public void AddNote(string noteText)
        {
            try
            {
                SelectAndSaveChangesFromPopup(noteText, "Note_Type");
            }
            catch (TimeoutException ex)
            {
                logger.Error("Error encountered in AddNote:{0}", ex.Message);
               
            }


        }

        public void ChangeStatus(string statusChangeNotes)
        {
            try
            {
                SelectAndSaveChangesFromPopup(statusChangeNotes, "Note_Status");
            }
            catch (TimeoutException ex)
            {
                logger.Error("TimeoutException encountered in ChangeStatus:{0}", ex.Message);

            }

        }

        public string GetCurrentStatus()


        {
            try
            {
                ElementLocator statusElement = new ElementLocator(Locator.ClassName, "status");
                IWebElement currentStatus = Driver.GetElement(statusElement);
                return currentStatus.Text;

            }
            catch(TimeoutException ex)
            {
                logger.Error("TimeoutException encountered in ChangeStatus:{0}", ex.Message);

            }
            return string.Empty;
        }

        public void  ClosePopUp()
        {
            ElementLocator closeButtom = new ElementLocator(Locator.CssSelector, "header a.close");
            Driver.GetElement(closeButtom).Click();

        }

        private void SelectAndSaveChangesFromPopup(string noteText,string dropDownId)
        {
            Driver.GetElement(new ElementLocator(Locator.ClassName, "ui-dialog-content")).JavaScriptClick();

            // String javaScript = string.Format("document.getElementById({0}).selectedIndex = 4", dropDownId);
            
            //((IJavaScriptExecutor)Driver).ExecuteScript(javaScript);

            //IWebElement noteTypes = Driver.GetElement(new ElementLocator(Locator.Id, dropDownId));

            //WebDriverWait waitForActivation = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
            //waitForActivation.Until(ExpectedConditions.ElementToBeClickable(noteTypes));
            //noteTypes.Click();



            //// IWebElement noteTypes = Driver.FindElement(By.Id(dropDownId));

            //Driver.Actions().Click(noteTypes).Perform();
            //Driver.Actions().SendKeys(noteTypes, Keys.ArrowDown).Perform();
            //Driver.Actions().SendKeys(noteTypes, Keys.ArrowDown).Perform();
            //Driver.Actions().SendKeys(noteTypes, Keys.Enter).Perform();



            ElementLocator noteTxt = new ElementLocator(Locator.Id, "Note_Text");
            Driver.GetElement(noteTxt).SendKeys(noteText);

            ElementLocator saveBtn = new ElementLocator(Locator.ClassName, "save");
            Driver.GetElement(saveBtn).Click();
          
        }

       

    }
}
