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
             
        public bool CheckWhetherCandidateRecordDisplayInViewMode(string firstName, string lastName)
        {
            return Driver.GetElement(candidateNameLink).Text.ToLowerInvariant().Contains(firstName.ToLowerInvariant()) && Driver.GetElement(candidateNameLink).Text.ToLowerInvariant().Contains(lastName.ToLowerInvariant()) ? true : false;

        }
    }
}
