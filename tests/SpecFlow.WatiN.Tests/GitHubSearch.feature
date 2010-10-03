Feature: GitHub search

  Scenario: Find SpecFlow repository
    Given I visit http://github.com/search
      And I fill in "q" with "specflow"
	  And I select "Repositories" from "type"
	  And I select "C#" from "language"
     When I press Enter
     Then I should see a link to "techtalk / SpecFlow"
	  And I should not see "Source Code"	  