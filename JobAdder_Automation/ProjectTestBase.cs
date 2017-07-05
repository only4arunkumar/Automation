﻿// <copyright file="ProjectTestBase.cs" company="Objectivity Bespoke Software Specialists">
// Copyright (c) Objectivity Bespoke Software Specialists. All rights reserved.
// </copyright>
// <license>
//     The MIT License (MIT)
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//     The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//     SOFTWARE.
// </license>

namespace Objectivity.Test.Automation.Tests.Features
{
    using System;

    using NUnit.Framework;
    using Objectivity.Test.Automation.Common;
    using Objectivity.Test.Automation.Common.Logger;

    using TechTalk.SpecFlow;
    using JobAdder_Automation.Pages;
    /// <summary>
    /// The base class for all tests
    /// </summary>
    [Binding]
    public class ProjectTestBase : TestBase
    {
        private readonly ScenarioContext scenarioContext;
        private readonly DriverContext driverContext = new DriverContext();

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectTestBase"/> class.
        /// </summary>
        /// <param name="scenarioContext"> Scenario Context </param>
        public ProjectTestBase(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Gets or sets logger instance for driver
        /// </summary>
        public TestLogger LogTest
        {
            get
            {
                return this.DriverContext.LogTest;
            }

            set
            {
                this.DriverContext.LogTest = value;
            }
        }

        /// <summary>
        /// Gets the browser manager
        /// </summary>
        protected DriverContext DriverContext
        {
            get
            {
                return this.driverContext;
            }
        }

        /// <summary>
        /// Before the class.
        /// </summary>
        [BeforeFeature]
        public static void BeforeClass()
        {
            StartPerformanceMeasure();
        }

        /// <summary>
        /// After the class.
        /// </summary>
        [AfterFeature]
        public static void AfterClass()
        {
            StopPerfromanceMeasure();
        }

        /// <summary>
        /// Before the test.
        /// </summary>
        [Before]
        public void BeforeTest()
        {
            this.DriverContext.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this.DriverContext.TestTitle = this.scenarioContext.ScenarioInfo.Title;
            this.LogTest.LogTestStarting(this.driverContext);
            this.DriverContext.Start();
            this.scenarioContext["DriverContext"] = this.DriverContext;
            LoginPage loginPage = new LoginPage(this.driverContext);
            loginPage.NavigateToLoginPage();
            loginPage.InputUserName("username");
            loginPage.InputPassword("password");
            loginPage.Logon();
        }

        [Before("ExplicitLogin")]
        public void ExplicitLoginBeforeTest()
        {
            this.DriverContext.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this.DriverContext.TestTitle = this.scenarioContext.ScenarioInfo.Title;
            this.LogTest.LogTestStarting(this.driverContext);
            this.DriverContext.Start();
            this.scenarioContext["DriverContext"] = this.DriverContext;
           
        }
        /// <summary>
        /// After the test.
        /// </summary>
        [After]
        public void AfterTest()
        {
            this.DriverContext.IsTestFailed = this.scenarioContext.TestError != null || !this.driverContext.VerifyMessages.Count.Equals(0);
            this.SaveTestDetailsIfTestFailed(this.driverContext);
            this.DriverContext.Stop();
            this.LogTest.LogTestEnding(this.driverContext);
            if (this.IsVerifyFailedAndClearMessages(this.driverContext) && this.scenarioContext.TestError == null)
            {
                Assert.Fail();
            }
        }
    }
}
