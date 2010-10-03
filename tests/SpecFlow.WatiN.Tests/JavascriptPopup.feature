Feature: Javascript Popup

Scenario: Press button and confirm
	Given I visit http://www.tizag.com/javascriptT/javascriptconfirm.php
	When I press "Leave Tizag.com" and confirm the popup

Scenario: Click link and confirm
	Given I visit http://www.michael-thomas.com/tech/javascript/ex_confirm.htm
	When I click "Confirm OK, then goto URL (uses onclick())" and confirm the popup