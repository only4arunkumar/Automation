using System;
using TechTalk.SpecFlow;
using Objectivity.Test.Automation.Tests.Features;
using Objectivity.Test.Automation.Common;
using JobAdder_Automation.Pages;
using NUnit.Framework;

namespace JobAdder_Automation.Step_Defenitions
{
    [Binding]
    public class LoginSteps 
    {

        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private LoginPage loginPage;
        public LoginSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.driverContext = ScenarioContext.Current["DriverContext"] as DriverContext;
        }
            
        [Given(@"I have navigated to login page")]
        public void GivenIHaveNavigatedToLoginPage()
        {
            loginPage = new LoginPage(this.driverContext);
            loginPage.NavigateToLoginPage();

        }
        
        [Given(@"I have entered valid credentials")]
        public void GivenIHaveEnteredValidCredentials()
        {
            loginPage.InputUserName("");
            loginPage.InputPassword("");
          
        }

        
        [When(@"I press submit")]
        public void WhenIPressSubmit()
        {
            loginPage.Logon();
        }
        
        [Then(@"I should be taken to defualt page")]
        public void ThenIShouldBeTakenToDefualtPage()
        {
            Verify.That(this.driverContext, () => Assert.True(loginPage.IsCurrentlyOnDefaultPage()));
        }
    }
}
