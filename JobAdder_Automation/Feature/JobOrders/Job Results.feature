Feature: Job Results
	Check whether user is able to view and perform basic operations on the Job
	records from Job results screen

Scenario: View defualt job results
	Given I have navigated to Jobs results page
	Then  the application displays the defualt Job results

Scenario: Filter JobOrder results using standard filters
	Given I have navigated to Jobs results page
	Then  the application allows to filter Joborder  results

Scenario: Invoke a SavedSearch on Job records
	Given I have navigated to Jobs results page
	Then  the application allows to invoke my SavedSearch on Jobs records

Scenario: Clearing an already selected SavedSearch on Job records
	Given I have navigated to Jobs results page
	And   I have invoked my Saved Search  on Job records
	Then  the application allows to clear the SavedSearch on Jobs records

Scenario: Filtering the Jobs results using the grid column filter
	Given I have navigated to Jobs results page
	Then  the application allows to filter Job results using 'CompanyName' and 'Jobadder'


Scenario: Adding a Job record to a folder
	Given I have navigated to Jobs results page
	Then  the application allows me to add Job records into folder

Scenario: Removing a Job record from a folder
	Given I have navigated to Jobs results page
	And   I have added a Job record to  a folder
	Then  the application allows me to remove the Job record form folder

Scenario: Invoking QuickView from Jobs  resultspage
	Given I have navigated to Jobs results page
	Then  the  application  allows me to  invoke  Quickview  from Job records


Scenario:Adding Notes to Job recrods and Vewing them in QuickView
	Given I have navigated to Jobs results page
	And   I have added a note to a Job record
	Then  the application displays the newly added notes in Jobs QuickView

Scenario: Changing Status of  JobOrder and Viewing the updated status
	Given I have navigated to Jobs results page
	Then  the application allows be to chage the status of the Job record




