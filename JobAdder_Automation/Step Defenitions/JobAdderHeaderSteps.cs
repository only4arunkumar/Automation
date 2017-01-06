using System;
using TechTalk.SpecFlow;
using Objectivity.Test.Automation.Tests.Features;
using Objectivity.Test.Automation.Common;
using JobAdder_Automation.Pages;
using NUnit.Framework;

namespace JobAdder_Automation
{
    [Binding]
    public class JobAdderHeaderSteps
    {
        private readonly ScenarioContext scenarioContext;
        private readonly DriverContext driverContext;
        private JobAdderHeaderPage headerPage;

        public JobAdderHeaderSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.driverContext = scenarioContext["DriverContext"] as DriverContext;
        }
        [Then(@"Links to JobAdder modules should be clickable")]
        public void ThenLinksToJobAdderModulesShouldBeClickable()
        {
            headerPage = new JobAdderHeaderPage(this.driverContext);
            Verify.That(this.driverContext,()=>Assert.IsTrue(headerPage.Check_ModuleLinksAccessibleFromHeader()));

        }

        [Then(@"Quicksearch should be invokable")]
        public void ThenQuicksearchShouldBeInvokable()
        {
            headerPage = new JobAdderHeaderPage(this.driverContext);
            Verify.That(this.driverContext, () => Assert.IsTrue(headerPage.Check_QuickSearch("job")));

        }

        [Then(@"QuickAdd should be invokable")]
        public void ThenQuickAddShouldBeInvokable()
        {
            headerPage = new JobAdderHeaderPage(this.driverContext);
            Verify.That(this.driverContext, () => Assert.IsTrue(headerPage.Check_QuickAddInvokable()));
        }

    }
}
