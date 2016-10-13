Feature: Job Results
	Check whether user is able to view and perform basic operations on the Job
	records from Job results screen

Scenario: View defualt job results
	Given I have successfully logged into JobAdder
	And   I have navigated to Jobs results page
	Then  the application displays the defualt Job results

Scenario: Filter JobOrder results using standard filters
	Given I have successfully logged into JobAdder
	And   I have navigated to Jobs results page
	Then  the application allows to filter Joborder  results

Scenario: Invoke a SavedSearch on Job records
	Given I have successfully logged into JobAdder
	And   I have navigated to Jobs results page
	Then  the application allows to invoke my SavedSearch on Jobs records

Scenario: Clearing an already selected SavedSearch on Job records
	Given I have successfully logged into JobAdder
	And   I have navigated to Jobs results page
	And   I have invoked my Saved Search  on Job records
	Then  the application allows to clear the SavedSearch on Jobs records

