Feature: AccountAPI
To Test a basic Bank system API where A user can create account, delete account, deposit to an account and withdraw from an account.

@AccountCreation
Scenario Outline: Create new Account with valid data
	And Account Initial Balance is "<InitialBalance>"
	And Account name is "<AccountName>"
	And Address is "<AccountAddress>"
	When User create a new account with above details
	Then Verify the response code is "<ResponseCode>"
	And Verify no error is returned
	And Verify the creation success message and get new account number
	And Verify the account details "<InitialBalance>" and "<AccountName>" are correct in the response
Examples: 
| Iteration | InitialBalance | AccountName   | AccountAddress     | ResponseCode | 
| 1         | $1000          | Rajesh Mittal | Ahmedabad, Gujarat | 200          | 

@AccountOperations
Scenario Outline: Deposit to new Account with valid data
	Given Account Balance before Deposit is "<InitialBalance>"
	And Account number is "<AccountNumber>"
	And Deposit amount is "<DepositAmount>"
	When User deposit amount to existing account with above details
	Then Verify the response code after transaction is "<ResponseCode>"
	And Verify no error is returned after transaction
	And Verify the success message "<SuccessMessage>"
	And Verify the transaction details "<NewBalance>" and "<AccountNumber>" are correct in the response
Examples: 
| Iteration | InitialBalance | DepositAmount | NewBalance | AccountNumber | ResponseCode | SuccessMessage                              |
| 1         | $1000          | $1000         | $2000      | 123           | 200          | 1000$ deposited to Account 123 successfully |

@AccountOperations
Scenario Outline: Withdraw from new Account with valid data
	Given Account Initial Balance is "<InitialBalance>"
	And Account number is "<AccountNumber>"
	And Withdraw amount is "<WithdrawAmount>"
	When User withdraw amount from existing account with above details
	Then Verify the response code after transaction is "<ResponseCode>"
	And Verify no error is returned after transaction
	And Verify the success message "<SuccessMessage>"
	And Verify the transaction details "<NewBalance>" and "<AccountNumber>" are correct in the response
Examples: 
| Iteration | InitialBalance | WithdrawAmount | NewBalance | AccountNumber | ResponseCode | SuccessMessage                              |
| 1         | $2000          | $1000          | $1000      | 123           | 200          | 1000$ withdrawn to Account 123 successfully |

@AccountDeletion
Scenario Outline: Delete existing Account with valid account number
	Given User submit delete request for account number "<AccountID>"
	Then Verify the response code after deletion is "<ResponseCode>"
	And Verify no error is returned after deletion
	And Verify the deletion success message for "<AccountID>"
Examples: 
| Iteration | InitialBalance | AccountName   | AccountAddress     | ResponseCode | 
| 1         | $1000          | Rajesh Mittal | Ahmedabad, Gujarat | 200          | 

