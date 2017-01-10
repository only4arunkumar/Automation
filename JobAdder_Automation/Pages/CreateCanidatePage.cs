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
using OpenQA.Selenium.Support.UI;

namespace JobAdder_Automation.Pages
{
    public class CreateCanidatePage: ProjectPageBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly ElementLocator canFirstName = new ElementLocator(Locator.Id, "FirstName");
        private readonly ElementLocator canLastNmae = new ElementLocator(Locator.Id, "LastName");
        private readonly ElementLocator canEmail = new ElementLocator(Locator.Id, "Email");
        private readonly ElementLocator canMobile = new ElementLocator(Locator.Id, "Mobile");
        private readonly ElementLocator canCreateBtn = new ElementLocator(Locator.XPath, "//button[contains(text(),'Create')]");
        private string FName;
        private string LName;

        public CreateCanidatePage(DriverContext driverContext):base(driverContext)
        {
            
        }
        
        public void ManullyFillCandidateData()
        {
            FName = DataHelper.GetRandomText(11);
                 
            this.Driver.GetElement(canFirstName).SendKeys(FName);
            LName = DataHelper.GetRandomText(11);
            this.Driver.GetElement(canLastNmae).SendKeys(LName);
            this.Driver.GetElement(canEmail).SendKeys(DataHelper.GetRandomEMail(FName));
            this.Driver.GetElement(canMobile).SendKeys(DataHelper.GetRandomPhone(10));
        }

        public void CreateAndSaveCandidateRecord()
        {

            Driver.WaitUntilElementIsNoLongerFound(new ElementLocator(Locator.ClassName, "blockOverlay"),30);
            Driver.GetElement(canCreateBtn).Click();
            

        }

        public bool CheckCanidateRecordDisplayed()
        {
            Driver.WaitForAjax();
            return this.Driver.Title.ToUpper().Contains(LName) && this.Driver.Title.ToUpper().Contains(FName);
        }

        public bool UploadCandidateResume()
        {
            try
            {
        

                FileInfo file = new FileInfo(".//TestData//Sample_Resume.pdf");
                IWebElement fileUpload = Driver.FindElements(By.CssSelector("input[type='file']"))[1];
                fileUpload.SendKeys(file.FullName);
                Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 5));
                
                FName = Driver.GetElement(canFirstName).GetAttribute("value");
                LName = Driver.GetElement(canLastNmae).GetAttribute("value");
                CreateAndSaveCandidateRecord();
               
            }
            catch (FileNotFoundException ex)
            {
                logger.Error("File not found exception while executing UploadCandidateResume:{0}", ex.Message);
                return false;
              
            }
            catch(NoSuchElementException ex)
            {
                logger.Error("No such Element exception while executing UploadCandidateResume:{0}", ex.Message);
                return false;
            }
            catch(TimeoutException ex)
            {
                logger.Error("Timeout exception while executing UploadCandidateResume:{0}", ex.Message);
            }
            return true;
        }

        public string GetCandidateFirstName()
        {
            return FName;
        }
        public string GetCandidateLastName()
        {
            return LName;
        }
       

      
    }
}
