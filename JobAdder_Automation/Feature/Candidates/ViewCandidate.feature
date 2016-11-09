Feature: View Candidate Records
	This feature covers the option of viewing a candidate record in view mode 


Scenario: Accessing a Candidate record from Candidate results
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page
	And   I have selected a candidate record from the candidate results 
	Then  The application displays the  candidate record in view mode

Scenario: Checking for Candidate delete confimration message
	Given I have successfully logged into JobAdder
	And   I have navigated to Candidates results page
	And   I have selected a candidate record from the candidate results
	When  I attempt to delete a Candidate record 
	Then  The  appllication displays a warning message


Scenario: Adding a Candidate to a JobOrder

