using System;
using TechTalk.SpecFlow;
using Objectivity.Test.Automation.Tests.Features;
using Objectivity.Test.Automation.Common;
using JobAdder_Automation.Pages;
using NUnit.Framework;

namespace JobAdder_Automation.Step_Defenitions
{
    [Binding]
    public class CommonSteps
    {
        private readonly ScenarioContext scenarioContext;
        private readonly DriverContext driverContext;
        public CommonSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.driverContext = scenarioContext["DriverContext"] as DriverContext;
        }

        [Given(@"I have successfully logged into JobAdder")]
        public void GivenIHaveSuccessfullyLoggedIntoJobAdder()
        {
          LoginPage  loginPage = new LoginPage(this.driverContext);
            loginPage.NavigateToLoginPage();
            loginPage.InputUserName("arunkumar+auqa2@jobadder.com");
            loginPage.InputPassword("Jiby@a714");
            loginPage.Logon();
        }

       



    }
}
