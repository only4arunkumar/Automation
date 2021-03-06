﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace JobAdder_Automation.Feature.Candidates
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CandidateResultsFeature : Xunit.IClassFixture<CandidateResultsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CandidateResults.feature"
#line hidden
        
        public CandidateResultsFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CandidateResults", "\tCheck whether user is able to view and perform basic operations on the candidate" +
                    "\r\n\trecords from Candidate results screen", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void SetFixture(CandidateResultsFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="View defualt candidate results")]
        [Xunit.TraitAttribute("FeatureTitle", "CandidateResults")]
        [Xunit.TraitAttribute("Description", "View defualt candidate results")]
        public virtual void ViewDefualtCandidateResults()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View defualt candidate results", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have navigated to Candidates results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.Then("the application displays the defualt results", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Filter Candidate results using standard filters")]
        [Xunit.TraitAttribute("FeatureTitle", "CandidateResults")]
        [Xunit.TraitAttribute("Description", "Filter Candidate results using standard filters")]
        public virtual void FilterCandidateResultsUsingStandardFilters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Filter Candidate results using standard filters", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given("I have navigated to Candidates results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
 testRunner.Then("the application allows to filter the results", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Invoke a SavedSearch on Candidate records")]
        [Xunit.TraitAttribute("FeatureTitle", "CandidateResults")]
        [Xunit.TraitAttribute("Description", "Invoke a SavedSearch on Candidate records")]
        public virtual void InvokeASavedSearchOnCandidateRecords()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invoke a SavedSearch on Candidate records", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("I have navigated to Candidates results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.Then("the application allows to invoke my SavedSearch", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Clearing an already selected SavedSearch on Candidate records")]
        [Xunit.TraitAttribute("FeatureTitle", "CandidateResults")]
        [Xunit.TraitAttribute("Description", "Clearing an already selected SavedSearch on Candidate records")]
        public virtual void ClearingAnAlreadySelectedSavedSearchOnCandidateRecords()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Clearing an already selected SavedSearch on Candidate records", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
 testRunner.Given("I have navigated to Candidates results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.And("I have invoked my Saved Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.Then("the application allows to clear the SavedSearch", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.TheoryAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "CandidateResults")]
        [Xunit.TraitAttribute("Description", "Filtering the Candidate results using the grid column filter")]
        [Xunit.InlineDataAttribute("CandidateName", "arun", new string[0])]
        public virtual void FilteringTheCandidateResultsUsingTheGridColumnFilter(string gridColumn, string filtervalue, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Filtering the Candidate results using the grid column filter", exampleTags);
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
 testRunner.Given("I have navigated to Candidates results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.Then(string.Format("the application allows to filter results using {0} and {1}", gridColumn, filtervalue), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Clearing the Column filter from Candidates results page")]
        [Xunit.TraitAttribute("FeatureTitle", "CandidateResults")]
        [Xunit.TraitAttribute("Description", "Clearing the Column filter from Candidates results page")]
        public virtual void ClearingTheColumnFilterFromCandidatesResultsPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Clearing the Column filter from Candidates results page", ((string[])(null)));
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
 testRunner.Given("I have navigated to Candidates results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.And("the application allows to filter results using \'CandidateName\' and \'jobadder\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.Then("the application allows me to clear column filter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Folder Operation for Candidate Record")]
        [Xunit.TraitAttribute("FeatureTitle", "CandidateResults")]
        [Xunit.TraitAttribute("Description", "Folder Operation for Candidate Record")]
        public virtual void FolderOperationForCandidateRecord()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Folder Operation for Candidate Record", ((string[])(null)));
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
 testRunner.Given("I have navigated to Candidates results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
 testRunner.Then("the application allows me to add records into folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
 testRunner.Then("the application allows me to remove the record form folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.TheoryAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "CandidateResults")]
        [Xunit.TraitAttribute("Description", "Performing Keyword Search on Candidate records")]
        [Xunit.InlineDataAttribute("\"\"C#\"\"", new string[0])]
        public virtual void PerformingKeywordSearchOnCandidateRecords(string keyword, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Performing Keyword Search on Candidate records", exampleTags);
#line 47
this.ScenarioSetup(scenarioInfo);
#line 48
 testRunner.Given("I have navigated to Candidates results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 49
 testRunner.Then(string.Format("the application allows me to perform {0} Search", keyword), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Invoking QuickView from Candidate  resultspage")]
        [Xunit.TraitAttribute("FeatureTitle", "CandidateResults")]
        [Xunit.TraitAttribute("Description", "Invoking QuickView from Candidate  resultspage")]
        public virtual void InvokingQuickViewFromCandidateResultspage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Invoking QuickView from Candidate  resultspage", ((string[])(null)));
#line 54
this.ScenarioSetup(scenarioInfo);
#line 55
 testRunner.Given("I have navigated to Candidates results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 56
 testRunner.Then("the  application  allows me to  invoke  Quickview", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Adding Notes to Candidate recrods and Vewing them in QuickView")]
        [Xunit.TraitAttribute("FeatureTitle", "CandidateResults")]
        [Xunit.TraitAttribute("Description", "Adding Notes to Candidate recrods and Vewing them in QuickView")]
        public virtual void AddingNotesToCandidateRecrodsAndVewingThemInQuickView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Adding Notes to Candidate recrods and Vewing them in QuickView", ((string[])(null)));
#line 58
this.ScenarioSetup(scenarioInfo);
#line 59
 testRunner.Given("I have navigated to Candidates results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 60
 testRunner.And("I have added a note to a record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.Then("the application displays the newly added notes in QuickView", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(DisplayName="Change status of a Candidate record")]
        [Xunit.TraitAttribute("FeatureTitle", "CandidateResults")]
        [Xunit.TraitAttribute("Description", "Change status of a Candidate record")]
        public virtual void ChangeStatusOfACandidateRecord()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change status of a Candidate record", ((string[])(null)));
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
 testRunner.Given("I have navigated to Candidates results page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
 testRunner.Then("the application allows me to change the status of a candidate record", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CandidateResultsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CandidateResultsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
