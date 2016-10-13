using System;
using NLog;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;

namespace JobAdder_Automation.Pages
{
    public class LoginPage :ProjectPageBase
    {
        public LoginPage(DriverContext driverContext):base(driverContext)
        {

        }
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly ElementLocator email = new ElementLocator(Locator.Id, "Email");
        private readonly ElementLocator password = new ElementLocator(Locator.Id, "Password");
        private readonly ElementLocator submit = new ElementLocator(Locator.ClassName, "submit");

        public ElementLocator Email
        {
            get
            {
                return email;
            }
        }

        public ElementLocator Password
        {
            get
            {
                return password;
            }
        }

        public void Logon()
        {
            logger.Info("Clicking Submit button in Login Page");
            this.Driver.GetElement(submit).Click();
            
        }

        public void NavigateToLoginPage()
        {
            this.Driver.NavigateTo(GetDefaultUrlValue());
        }

        public void InputUserName(string username)
        {
            this.Driver.GetElement(email).SendKeys(username);
            Logon();
        }

        public void InputPassword(string pwd)
        {
            this.Driver.GetElement(password).SendKeys(pwd);
        }

        

    }
}
