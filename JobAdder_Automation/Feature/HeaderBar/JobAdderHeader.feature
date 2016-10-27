Feature: JobAdderHeader
	Inorder to  check whether  individual JobAdder modules 
	can be invoked from the main header bar 


Scenario: Accessing JobAdder modules from header
	Given I have successfully logged into JobAdder
	Then  Links to JobAdder modules should be clickable 

Scenario: Invoking Quick Search from header
	Given I have successfully logged into JobAdder
	Then  Quicksearch should be invokable 

Scenario: Invoking Quick Add from header
	Given I have successfully logged into JobAdder
	Then  QuickAdd should be invokable 