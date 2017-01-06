Feature: Login
	Check whether login attempt with valid credential
	takes the user to default page. 

@Login @ExplicitLogin
Scenario: Successful login to JobAdder
	Given I have navigated to login page 
	And   I have entered valid credentials 
	When  I press submit
    Then  I should be taken to defualt page
