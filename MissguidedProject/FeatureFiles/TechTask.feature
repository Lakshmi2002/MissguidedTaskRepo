Feature: Checkout as a guest

Scenario: Verify customer is able to buy a dress under 20 pounds
	Given I am on homepage
	When I select the “Dresses” category	
	Then dresses PLP is displayed
	When I select an item under the value of £20.00	
	Then only dresses under £20 are displayed
	When I select a dress from the list	
	Then PDP of the selected dress should be displayed	
	When I add the item to basket
	Then selected product should be visible at checkout
	And I should be able to checkout as a guest


	