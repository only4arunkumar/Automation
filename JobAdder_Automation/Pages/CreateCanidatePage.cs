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
    public class CreateCanidatePage: ProjectPageBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly ElementLocator canFirstName = new ElementLocator(Locator.Id, "FirstName");
        private readonly ElementLocator canLastNmae = new ElementLocator(Locator.Id, "LastName");
        private readonly ElementLocator canEmail = new ElementLocator(Locator.Id, "Email");
        private readonly ElementLocator canMobile = new ElementLocator(Locator.Id, "Mobile");
        private readonly ElementLocator canCreateBtn = new ElementLocator(Locator.XPath, "//button[contains(text(),'Create')]");
        public string FName;
        public string LName;

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


                FileInfo file = new FileInfo("../JobAdder_Automation/bin/Debug/TestData/Sample_Resume.pdf");
                IWebElement fileUpload = Driver.FindElements(By.CssSelector("input[type='file']"))[1];
                fileUpload.SendKeys(file.FullName);
                Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 5));
                Driver.WaitForAjax();
                fileUpload.Submit();    
                           


            }
            catch (Exception ex)
            {

                throw;
            }
            
      
            return true;
        }

      
    }
}
