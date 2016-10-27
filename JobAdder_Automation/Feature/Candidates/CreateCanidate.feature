Feature: CreateCanidate
	This feature covers the  various possiblities of creating a  new 
	candidate record  in JobAdder


Scenario: Create a Candidate by manually entering the values
	Given I have successfully logged into JobAdder
	And I have navigated to create candidate page
	And I have manually entered the mandaory candidate fields
	When I press create button
	Then the application creates the candidate record and display the result in view mode


Scenario: Create a Candidate by parsing individual resume
	Given I have successfully logged into JobAdder
	And I have navigated to create candidate page
	And I have uploaded a candidate resume to file-upload area
	When I press create button
	Then the application creates the candidate record from resume and display the result in view mode


