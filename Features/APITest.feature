Feature: APITest
Testing various calles for api tests
@mytag
Scenario: Create new user
	Given Input name "Lindsay"
	And Input Job "Ferguson"
	When Send request to use
	Then Validate user is created

Scenario: Create new user with out job and validate Error Response
	Given Input name "Lindsay"
	When Send request to use
	Then Validate Error Response

Scenario: Get list of users
    Given baseurl 
	When  Get request to use
	Then  Validate list of users

Scenario: Get single user 
	When  Get request to use for single user
	Then  Validate  user data

Scenario: Update Existing User
    Given Input name "morpheus"   
	And Input Job "zion resident"
	When Send request to update
	Then Validate user is updated


Scenario:Patch Existing User
    When Send request to Patch
	Then Validate user is patched
          