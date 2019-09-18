Feature: Complete purchase by making payment
	

@mytag
Scenario Outline: Complete payment
	Given I navigate to landing page using paymentRedirect URL
	When I click Next button
	Then I should see payment provider page
	Then select Payment provider as <bankname> and click continue button
	Then I should see login page
	When I enter <userid> and <pin> and click login button
	Then I shoud see error message
	And I click cancel button
	Then I should see gametwist page title contains <title>
	Then I take screenshot and close the browser
	Examples: 
	| bankname       | userid | pin   | title                           |
	| "Bank Austria" | "abcd" | "xyz" | "Play FREE Online Casino games" |