using System;
using System.Linq;
using System.Runtime.Serialization;
using NLog;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace JobAdder_Automation.Pages
{
    public class ResultsPageBase:ProjectPageBase
    {
        public ResultsPageBase(DriverContext driverContext,string moduleName):base(driverContext)
        {
            gridId = string.Format("Grid_{0}", moduleName);
        }
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string gridId;
        private int gridRowCount = 0;

        protected int GetGridRowCount()
        {
            int rowCount = -1;
            ElementLocator resultGrid = new ElementLocator(Locator.Id, gridId);
            try
            {
                int.TryParse(Driver.GetElement(resultGrid).GetAttribute("data-grid-total-row-count"), out rowCount);
                return rowCount;
            }catch(TimeoutException ex)
            {
                logger.Error("Encountered exception in GetGridCount:{0}", ex.Message);
            }
            catch(StaleElementReferenceException ex )
            {
                logger.Error("Encountered exception in GetGridCount:{0}", ex.Message);
            }
            return rowCount;
       }

        protected int GetCurrentPageRowCount()
        {
            
            ElementLocator resultCount = new ElementLocator(Locator.ClassName, "fa-search-plus");
            try
            {
                return Driver.GetElements(resultCount).Count;
                
            }
            catch (TimeoutException ex)
            {
                logger.Error("Encountered exception in GetCurrentPageRowCount:{0}", ex.Message);
            }
            catch (StaleElementReferenceException ex)
            {
                logger.Error("Encountered exception in GetCurrentPageRowCount:{0}", ex.Message);
            }
            return 0;
             
        }
        protected bool FilterGridUsingStandardFilters()
        {
            int initialRowCount = GetGridRowCount();
            ElementLocator invokestandardFilter = new ElementLocator(Locator.ClassName, "view");
            ElementLocator standardFilter= new ElementLocator(Locator.CssSelector, ".view .ui-menu-item");
            string initialFilterName;
            Driver.GetElement(invokestandardFilter).Click();
           
            try
            {
                IList<IWebElement> filterList = Driver.GetElements(standardFilter);
                if (filterList.Count > 2)
                {
                  
                    initialFilterName = invokestandardFilter.Value;
                    filterList[filterList.Count-1].Click();
                    Driver.WaitForAjax();
                    if(GetGridRowCount() != initialRowCount)
                    {
                        return true;
                    }
                    else
                    {
                        if (!initialFilterName.Equals(invokestandardFilter.Value))
                            return true;
                        else
                            return false;
                    }
                   
                }
                else
                {
                    return false;
                }
            }catch(TimeoutException ex)
            {
                logger.Error("Timeout exception in FilterGridUsingStandardFilters{0}", ex.Message);
            }
            return false;

        }
       
        protected bool InvokeSavedSearch()
        {
            ElementLocator invokeSavedSearch = new ElementLocator(Locator.CssSelector, ".savedsearch .fa.fa-search");
            ElementLocator savedSearches = new ElementLocator(Locator.CssSelector, "ul.savedsearch");
            try
            {
                Driver.GetElement(invokeSavedSearch).Click();
                gridRowCount = GetGridRowCount();
                Driver.GetElement(savedSearches, x => x.Displayed).Click();
                Driver.WaitForAjax();
                if(gridRowCount > GetGridRowCount())
                {
                    logger.Debug("The Initial rowcount {0} and  rowcount after filtering{1}", gridRowCount, GetGridRowCount());
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(TimeoutException ex)
            {
                logger.Error("Timeout exception in FilterGridUsingStandardFilters{0}", ex.InnerException.Message);
            }
            return false;

        }

        protected bool ClearSavedSearch()
        {
            ElementLocator clearSavedSearch = new ElementLocator(Locator.CssSelector,".savedsearch .remove");
            try
            {
                logger.Debug("Grid row count after invoking Saved Search :{0}", GetGridRowCount());
                Driver.GetElement(clearSavedSearch).Click();
                Driver.WaitForAjax();
                if (gridRowCount == GetGridRowCount())
                {
                    logger.Debug("Grid row count after clearing Saved Search :{0}", GetGridRowCount());
                    return true;
                }
                else
                {
                    return false;
                }

            }catch(TimeoutException ex)
            {
                logger.Error("Timeout exception in ClearSavedSearch{0}", ex.InnerException.Message);
            }
            return false;
            
        }

        protected bool FilterResultsUsingColumnFilter(string module,string columnName, string filterText)
        {
            int initialrowCount = GetGridRowCount();
            int currentrowCount = 0;
            ElementLocator columnFilter = new ElementLocator(Locator.Id, "Grid_{0}_Filter_{1}");
            

            try
            {
                IWebElement resultFilter = Driver.GetElement(columnFilter.Format(module, columnName));
                
               
                Driver.Actions().SendKeys(resultFilter, filterText).Perform();
                Driver.Actions().SendKeys(resultFilter, Keys.Enter).Perform();
                Driver.WaitForAjax();
                currentrowCount = GetGridRowCount();
                if (initialrowCount != currentrowCount)
                {
                   return currentrowCount == 0 ? true : Driver.PageSource.Contains(filterText);
                }
               
            }
            catch (TimeoutException ex)
            {
                logger.Error("Encountered exception in FilterResultsUsingColumnFilter:{0}", ex.Message);
            }
            return false;
        }

        protected bool ClearColumnFilter()
        {
            ElementLocator clearColumnFilter = new ElementLocator(Locator.CssSelector, "button.clear");
            int rowCount = GetGridRowCount();

            try
            {
                Driver.GetElement(clearColumnFilter).Click();
                Driver.WaitForAjax();
               if (rowCount <= GetGridRowCount())
                {
                   return true;
                }
               
            }
            catch (TimeoutException ex)
            {

                logger.Error("Timeout exception in ClearColumnFilter{0}", ex.InnerException.Message);
            }

            return false;
        }


        protected bool AddRecordsToFolder(string moduleName)
        {
           
            try
            {
                if (GetGridRowCount() > 0)
                {
                    SelectaRecordFromResultsGrid(moduleName);
                    ClickAddtoFolderButton();
                    CreateFolder(moduleName);

                    IWebElement newFolder = Driver.FindElement(By.CssSelector("li .checked"));
                    if (newFolder.Text.Equals(string.Format("RegressionFolder-{0}", moduleName)))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    logger.Error("No records avaible for adding them to folder");
                    return false;
                }
            }
            catch (TimeoutException ex)
            {

                logger.Error("Timeout exception in AddRecordsToFolder{0}", ex.InnerException.Message);
            }
            catch(NoSuchElementException ex)
            {
                logger.Error("NoSuchElementException in AddRecordsToFolder{0}", ex.InnerException.Message);
            }
            catch(Exception ex)
            {
                logger.Error("General Excepetion handler in AddRecordsToFolder{0}", ex.InnerException.Message);
            }
            return false;
            
        }

        protected bool RemoveRecordFromFolder(string moduleName)
        {
            InvokeFolderFilter(moduleName);
            if (GetGridRowCount() > 0)
            {
                SelectAllRecordsFromGrid(moduleName);
                ClickAddtoFolderButton();
                ToggleFolderSelection();
                ClearFolderFilter();
                

                try
                {
                    Driver.FindElement(By.LinkText(string.Format("RegressionFolder-{0}", moduleName)));
                }
                catch (NoSuchElementException)
                {
                    logger.Info("Record Successfully removed from the folder");
                    return true;
                }

            }
            return false;
        }

        protected bool PerformKeywordSearch(string moduleName, string filterText)
        {
            int initialRowCount = GetGridRowCount();
            ElementLocator keywordSearchCtrl = new ElementLocator(Locator.Id, "{0}_Search_Keywords");
            IWebElement keywordCtrl = Driver.GetElement(keywordSearchCtrl.Format(moduleName));
            keywordCtrl.SendKeys(filterText);
            keywordCtrl.SendKeys(Keys.Enter);
            Driver.WaitForAjax();
            return initialRowCount > GetGridRowCount() ? true : false;
           
        }

        protected bool InvokeQuickView()
        {
            try
            {
                ElementLocator quickView = new ElementLocator(Locator.ClassName, "fa-search-plus");
                Driver.GetElement(quickView).Click();
                Driver.WaitForAjax();
                ElementLocator popup = new ElementLocator(Locator.ClassName, "popup-details");
                if(Driver.GetElement(popup).Enabled)
                {
                    return true;
                }
            }
            catch (TimeoutException ex)
            {
                logger.Error("Error while invoking QuickView :{0}", ex.Message);
            }
            return false;
        }

        protected bool  InvokeQuickViewOnRecord( string recordId)
        {

            try
            {
                
                string linktext = string.Format("a[href$='/{0}'", recordId);

                IWebElement quickView=  Driver.GetElement(new ElementLocator(Locator.CssSelector, linktext));
                         

                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                js.ExecuteScript("var evt = document.createEvent('MouseEvents');" + "evt.initMouseEvent('click',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" + "arguments[0].dispatchEvent(evt);", quickView);
                
                return true;
            }
            catch (NoSuchElementException ex)
            {
                
                logger.Error("No Such Element exception  in  InvokeQuickViewOnRecord :{0}", ex.Message);
                
            }
            catch(InvalidOperationException ex)
            {
                logger.Error("Invalid operation exception  in  InvokeQuickViewOnRecord :{0}", ex.Message);
            }
            return false;
        }

        protected bool SortGrid()
        {
            try
            {
                ElementLocator sortColumnHeader = new ElementLocator(Locator.CssSelector, "a.sort");
                Driver.GetElement(sortColumnHeader).Click();
                Driver.WaitForAjax();
                return true;
            }catch(TimeoutException ex)
            {
                logger.Error("Error while Invoking Grid Sort Operation:{0}", ex.Message);
            }
            return false;
           
        }
        
        protected bool ChangeRecordStatus(string moduleName)
        {
            SortGrid();
            string recordId = SelectaRecordFromResultsGrid(moduleName);
            PopUpPage popup = new PopUpPage(DriverContext);
            InvokeQuickViewOnRecord(recordId);
            string status = popup.GetCurrentStatus();
            popup.ClosePopUp();
            InvokeHeaderMenu("Actions");
            ClickMenuItem("Change status");
            popup.ChangeStatus("Regressson Status Change");
           
            Driver.WaitForAjax();
            InvokeQuickViewOnRecord(recordId);
            return popup.GetCurrentStatus()!=status? true :false;

        }

        protected bool CheckForLatestNotes()
        {
            try
            {
                PopUpPage notesPopup = new PopUpPage(this.DriverContext);
                notesPopup.SelectTab("notes");
                return notesPopup.GetLatestNoteText().Trim().Equals("Regression Testing");
            }
            catch (NoSuchElementException ex)
            {

                logger.Error("No Such Element exception  in  CheckForLatestNotes :{0}", ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                logger.Error("Invalid operation exception  in  CheckForLatestNotes :{0}", ex.Message);
            }
            return false;
            
        }

        protected void SelectAllRecordsFromGrid(string moduleName)
        {
            Driver.FindElement(By.Id(string.Format("Grid_{0}_SelectAll", moduleName))).Click();
            Driver.WaitForAjax();
        }
        protected string SelectaRecordFromResultsGrid(string moduleName)
        {
            Random indexValue = new Random();
            string gridRecordSelector = string.Format("Grid_{0}_Select_{1}", moduleName, indexValue.Next(0, GetCurrentPageRowCount()));
            IWebElement candidateRecord = Driver.FindElement(By.Id(gridRecordSelector));
            candidateRecord.Click();
            return candidateRecord.GetAttribute("value");
          
        }

        protected string OpenARecordInViewMode(string moduleName)
        {
            try
            {
                Random indexValue = new Random();
                string selectorText = string.Format("table.primary a.{0}-link", moduleName);
                ElementLocator recordselector = new ElementLocator(Locator.CssSelector, selectorText);
                int recordIndex = indexValue.Next(0, GetCurrentPageRowCount());
                string recordId = Driver.GetElements(recordselector)[recordIndex].GetAttribute("href").Split('/').Last();
                Driver.GetElements(recordselector)[recordIndex].Click();
                return recordId;

            }
            catch (NoSuchElementException ex)
            {
                
                logger.Error("NoSuchElementException encuntered in OpenARecordInViewMode :{0}", ex.Message);
                return string.Empty;
            }
            catch (TimeoutException ex)
            {

                logger.Error("TimeoutException encuntered in OpenARecordInViewMode :{0}", ex.Message);
                return string.Empty;
            }
            catch(IndexOutOfRangeException ex)
            {
                logger.Error("IndexOutOfRangeException encuntered in OpenARecordInViewMode :{0}", ex.Message);
                return string.Empty;
            }
            catch(NullReferenceException ex)
            {
                logger.Error("Nullrefrence exception encuntered in OpenARecordInViewMode :{0}", ex.Message);
                return string.Empty;
            }
           

        }

        protected void InvokeHeaderMenu(string name)
        {
            ElementLocator headerMenu = new ElementLocator(Locator.ClassName, "actions");
            IWebElement menuSelection = Driver.GetElements(headerMenu).Single((x) => x.Text == name);
            menuSelection.Click();
            Driver.WaitForAjax();
        }

        protected void ClickMenuItem(string menuText)
        {
            ElementLocator menuItem = new ElementLocator(Locator.LinkText, menuText);
            Driver.GetElement(menuItem).Click();
        }

        private string InvokeFolderFilter(string folderName)
        {
            IWebElement folderFilter = Driver.FindElement(By.ClassName("fa-folder-open"));
            folderFilter.Click();
            Driver.WaitForAjax();
            string fName = string.Format("RegressionFolder-{0}", folderName);
            Driver.FindElement(By.LinkText(fName)).Click();
            Driver.WaitForAjax();
            return fName;
        }

        private void ClearFolderFilter()
        {
            Driver.FindElement(By.CssSelector("a.fa-remove")).Click();
            Driver.WaitForAjax();
        }

        private void ToggleFolderSelection()
        {
            ElementLocator newFolder = new ElementLocator(Locator.CssSelector, "li .checked");
            Driver.GetElement(newFolder).Click();
        }
             
        private void ClickAddtoFolderButton()
        {
            IWebElement addFolderButton = Driver.FindElement(By.LinkText("Add to Folder"));
            addFolderButton.Click();
            Driver.WaitForAjax();
        }

        private void CreateFolder(string moduleName)
        {

            IWebElement folderName = Driver.FindElements(By.CssSelector("label.input input")).Single((x) => x.Displayed == true);
            folderName.SendKeys(string.Format("RegressionFolder-{0}", moduleName));
            folderName.SendKeys(Keys.Enter);
            Driver.WaitForAjax();
        }

        


        
    }
}

 