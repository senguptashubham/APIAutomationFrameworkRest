Feature: Dummy
To test the dummy api

@dummy
Scenario Outline: Create dummy Account
	Given Dummy Account Initial Balance is "<InitialBalance>"
	And Dummy Account name is "<AccountName>"
	And Dummy Account Address is "<AccountAddress>"
	When User create a Dummy Account with above details
	Then Verify the dummy response code is "<ResponseCode>"
	And Verify the dummy account details "<InitialBalance>" and "<AccountName>" are correct in the response
Examples: 
| Iteration | InitialBalance | AccountName   | AccountAddress     | ResponseCode |
| 1         | $1000          | Rajesh Mittal | Ahmedabad, Gujarat | 201          |
