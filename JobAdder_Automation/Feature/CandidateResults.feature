Feature: CandidateResults
	Check whether user is able to view and perform basic operations on the candidate
	records from Candidate results screen


Scenario: View defualt candidate results
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page
	Then  the application displays the defualt results

Scenario: Filter Candidate results using standard filters
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page
	Then  the application allows to filter the results


Scenario: Invoke a SavedSearch on Candidate records
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page
	Then  the application allows to invoke my SavedSearch

Scenario: Clearing an already selected SavedSearch on Candidate records
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page
	And   I have invoked my Saved Search
	Then  the application allows to clear the SavedSearch

Scenario Outline: Filtering the Candidate results using the grid column filter
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page
	Then  the application allows to filter results using <gridColumn> and <filtervalue>
	Examples: 
	| gridColumn      | filtervalue |
	| CandidateName   | arun        |
	


Scenario: Clearing the Column filter from Candidates results page
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page 
	And   the application allows to filter results using 'CandidateName' and 'jobadder'
	Then  the application allows me to clear column filter



Scenario: Adding a Candidate record to a folder
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page
	Then  the application allows me to add records into folder


Scenario: Removing a Candidate record from a folder
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page
	And   I have added a candidate record to  a folder
	Then  the application allows me to remove the record form folder


Scenario Outline: Performing Keyword Search on Candidate records
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page
	Then  the application allows me to perform <Keyword> Search
	Examples: 
	| Keyword |
	| ""C#""  |
	
Scenario: Invoking QuickView from Candidate  resultspage
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page
	Then  the  application  allows me to  invoke  Quickview 

Scenario:Adding Notes to Candidate recrods and Vewing them in QuickView
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page
	And   I have added a note to a record
	Then  the application displays the newly added notes in QuickView

Scenario: Change status of a Candidate record 
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page
	Then  the application allows me to change the status of a candidate record

