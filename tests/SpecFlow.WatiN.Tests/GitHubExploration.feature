Feature: GitHub exploration

Scenario: Explore projects written in Boo
	Given I visit http://github.com/explore
	 And I see "Explore GitHub"
	When I click "Languages"
	 And I click "Boo"
	Then I should be at http://github.com/languages/Boo
	 And I should not be at http://github.com/languages/FORTRAN"
	 And the browser's title should contain "Boo - GitHub"
	 And the browser's title should not contain "FORTRAN"
