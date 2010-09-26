Feature: Google search

  Scenario: Find SpecFlow technical concepts
	Given I go to http://www.google.com/en
      And I fill in "q" with "specflow"
	 When I press "Google Search"
	 Then I should see "SpecFlow - Pragmatic BDD for .NET"
	 When I click "SpecFlow - Pragmatic BDD for .NET"
 	  And I click "specflow"
 	  And I click "technical concepts"
	 Then I should see "We strive to be fully compatible with the Gherkin language"

  Scenario: Find TekPub's 'Concepts' image for SpecFlow video
	Given I go to http://www.google.com/advanced_image_search?hl=en&sout=1
	  And I choose "Use strict filtering"
	  And I fill in "as_q" with "specflow tekpub"
	 When I press "Google Search"
	 Then I should see "Tekpub - Concepts"
