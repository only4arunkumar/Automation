using System;
using System.Collections.Generic;
using NLog;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;
using OpenQA.Selenium;

namespace JobAdder_Automation.Pages
{
    public class JobAdderHeaderPage: ProjectPageBase
    {
        
        public JobAdderHeaderPage(DriverContext driverContext):base(driverContext)
        {
         
            
        }
        private static Logger logger = LogManager.GetCurrentClassLogger();
       
        public bool Check_ModuleLinksAccessibleFromHeader()
        {
              ElementLocator[] headerLinks = {    new ElementLocator(Locator.LinkText, "Jobs"),
                                                  new ElementLocator(Locator.LinkText, "Job Ads"),
                                                  new ElementLocator(Locator.LinkText, "Job Applications"),
                                                  new ElementLocator(Locator.LinkText, "Candidates"),
                                                  new ElementLocator(Locator.LinkText, "Placements"),
                                                  new ElementLocator(Locator.LinkText, "Companies"),
                                                  new ElementLocator(Locator.LinkText, "Contacts"),
                                                  new ElementLocator(Locator.LinkText, "Reports"),
                                                  new ElementLocator(Locator.LinkText, "Admin")

                                               };

            try
            {
                foreach (ElementLocator currentElement in headerLinks)
                {
                    if (!Driver.GetElement(currentElement).Enabled)
                    {
                        
                        logger.Error("Header link not enabled for :{0}", currentElement.Value);
                        return false;
                    }
                }
            }
            catch (TimeoutException ex)
            {

                logger.Error("No Such Element Exception {0}", ex.Message);
                return false;
            }
            return true;
        }

        public bool Check_QuickSearch(string searchVal)
        {
            ElementLocator quickSearch = new ElementLocator(Locator.CssSelector, ".query input");
            try
            {
                IWebElement search = Driver.GetElement(quickSearch);
                ElementLocator result = new ElementLocator(Locator.ClassName, "results");
                if (!search.Enabled)
                {
                    return false;

                }
                search.Click();
                search.SendKeys(searchVal);
                Driver.WaitForAjax();
                if (Driver.GetElement(result).Displayed)
                {
                    return true;
                }

            }
            catch (TimeoutException ex)
            {
                logger.Error("Timeout Exception in Check_QuickSearch :{0}", ex.Message);
                
            }
            catch(Exception ex)
            {
                logger.Error("General Exception{0}", ex.Message);
            }
            return false;
        }

        public bool Check_QuickAddInvokable()
        {
            ElementLocator quickAdd = new ElementLocator(Locator.Id, "quick-links");

            try
            {
               IWebElement qadd = Driver.GetElement(quickAdd);
               if (qadd.Enabled)
               {
                    qadd.Click();
                    Driver.WaitForAjax();
                    ElementLocator quickAddMenu = new ElementLocator(Locator.CssSelector, "#quick-links .float-menu");
                    if (Driver.GetElement(quickAddMenu).Enabled)
                        return true;
                    else
                        return false;
               }
               else
                {
                    return false;
                }

            }
            catch (TimeoutException ex)
            {
                logger.Error("Timeout Exception in Check_QuickAddInvokable :{0}", ex.Message);

            }
            catch (Exception ex)
            {
                logger.Error("General Exception{0}", ex.Message);
            }
            return false;

        }

        public void Navigate_To_Module(string module)
        {
            ElementLocator headerLink = new ElementLocator(Locator.LinkText, module);
            Driver.GetElement(headerLink).Click();
        }
    }
}
