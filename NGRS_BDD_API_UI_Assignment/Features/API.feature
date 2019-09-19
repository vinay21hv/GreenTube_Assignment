Feature: Assignment Task
	A registered player should be able to make a purchase on Gametwist.com


Scenario Outline: 1 Login
	Given I have endpoint <url>
	When I perform POST operation to login with user <nickname> and <password>
	Then I should see the status code for login as <statuscode>
	Examples:
	| url                                              | nickname        | password   | statuscode |
	| "https://www.gametwist.com/nrgs/en/api/login-v1" | "testuser24091" | "Test@123" | 200        |

Scenario Outline: 2 AddConsent
	Given I have endpoint <url>
	When I perform POST operation to add consent for <consentType> with <acceptance>
	Then I should see the status code for add consent as <statuscode>
	Examples:
	| url                                                        | consentType                 | acceptance | statuscode |
	| "https://www.gametwist.com/nrgs/en/api/consent/consent-v1" | "GeneralTermsAndConditions" | "true"     | 200        |
	| "https://www.gametwist.com/nrgs/en/api/consent/consent-v1" | "DataPrivacyPolicy"         | "true"     | 200        |
	| "https://www.gametwist.com/nrgs/en/api/consent/consent-v1" | "MarketingProfiling"        | "true"     | 200        |

Scenario Outline: 3 VerifyConsent
	Given I have endpoint <url>
	When I perform GET operation to verify consent for <consentType>
	Then I should see the status code for verify consent as <statuscode>
	And I should see the <consentParam> as <consentValue>
	Examples:
	| url                                                        | consentType                 | statuscode | consentParam  | consentValue |
	| "https://www.gametwist.com/nrgs/en/api/consent/consent-v1" | "GeneralTermsAndConditions" | 200        | "wasAccepted" | "true"       |
	| "https://www.gametwist.com/nrgs/en/api/consent/consent-v1" | "DataPrivacyPolicy"         | 200        | "wasAccepted" | "true"       |
	| "https://www.gametwist.com/nrgs/en/api/consent/consent-v1" | "MarketingProfiling"        | 200        | "wasAccepted" | "true"       |

Scenario Outline: 4 UpgradeToFullRegistration
	Given I have endpoint <url>
	When I perform POST operation to Upgrade To Full Registration
	Then I should see the status code for full registration as <statuscode>
	Examples:
	| url                                                                         | statuscode |
	| "https://www.gametwist.com/nrgs/en/api/player/upgradeToFullRegistration-v1" | 200        |

Scenario Outline: 5 Purchase
	Given I have endpoint <url>
	When I perform POST operation for item purchase
	Then I should see the status code for purchase as <statuscode>
	And I capture payment URL from the response
	Examples:
	| url                                                                                      | statuscode |
	| "https://payments-api-v1-at.greentube.com/gametwist.widgets.web.site/en/api/purchase-v1" | 200        |