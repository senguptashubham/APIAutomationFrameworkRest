using APIAutomationFrameworkRest.Models.Requests;
using APIAutomationFrameworkRest.Models.Responses;
using APIAutomationFrameworkRest.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APIAutomationFrameworkRest.StepDefinitions
{
    [Binding]
    public class DepositWithdrawApiStepDefs
    {
        private DepositWithdrawAccountRequest depositWithdrawAccountRequest;
        private RestResponse restResponse;
        private ScenarioContext scenarioContext;
        private HttpStatusCode statusCode;
        int currBal;
        public DepositWithdrawApiStepDefs(ScenarioContext scenarioContext, DepositWithdrawAccountRequest depositWithdrawAccountRequest)
        {
            this.scenarioContext = scenarioContext;
            this.depositWithdrawAccountRequest = depositWithdrawAccountRequest;

        }

        [Given(@"Account Balance before Deposit is ""([^""]*)""")]
        public void GivenAccountBalanceBeforeDepositIs(string bal)
        {
            currBal = Int32.Parse(bal.Split("$")[1]);
        }

        [Given(@"Account number is ""([^""]*)""")]
        public void GivenAccountNumberIs(string accountNo)
        {
            depositWithdrawAccountRequest.AccountNumber = accountNo;
        }

        [Given(@"Deposit amount is ""([^""]*)""")]
        public void GivenDepositAmountIs(string amount)
        {
            int amt = Int32.Parse(amount.Split("$")[1]);
            depositWithdrawAccountRequest.Amount = amt;
            currBal += amt;
        }

        [When(@"User deposit amount to existing account with above details")]
        public async Task WhenUserDepositAmountToExistingAccountWithAboveDetails()
        {
            var accountClient = new RestApiClient("http://localhost:8080");
            restResponse = await accountClient.DepositAccount<DepositWithdrawAccountRequest>(depositWithdrawAccountRequest);
        }

        [Then(@"Verify the response code after transaction is ""([^""]*)""")]
        public void ThenVerifyTheResponseCodeAfterTransactionIs(string code)
        {
            statusCode = restResponse.StatusCode;
            int actual = (int)statusCode;
            int expected = Int32.Parse(code);
            Assert.AreEqual(expected, actual);
        }

        [Then(@"Verify no error is returned after transaction")]
        public void ThenVerifyNoErrorIsReturnedAfterTransaction()
        {
            var content = Helper.GetContent<DepositWithdrawAccountResponse>(restResponse);
            Assert.IsEmpty(content.Errors);
        }

        [Then(@"Verify the success message ""([^""]*)""")]
        public void ThenVerifyTheSuccessMessage(string msg)
        {
            var content = Helper.GetContent<DepositWithdrawAccountResponse>(restResponse);
            Assert.AreEqual(msg, content.Message);
        }

        [Then(@"Verify the transaction details ""([^""]*)"" and ""([^""]*)"" are correct in the response")]
        public void ThenVerifyTheTransactionDetailsAndAreCorrectInTheResponse(string newBalance, string accountNo)
        {
            int balance = Int32.Parse(newBalance.Split("$")[1]);
            var content = Helper.GetContent<CreateAccountResponse>(restResponse);
            Assert.AreEqual(balance, content.Data.NewBalance);
            Assert.AreEqual(accountNo, content.Data.AccountNumber);
            Assert.AreEqual(currBal, balance);
        }

        [Given(@"Withdraw amount is ""([^""]*)""")]
        public void GivenWithdrawAmountIs(string amount)
        {
            int amt = Int32.Parse(amount.Split("$")[1]);
            depositWithdrawAccountRequest.Amount = amt;
            currBal -= amt;
        }

        [When(@"User withdraw amount from existing account with above details")]
        public async Task WhenUserWithdrawAmountFromExistingAccountWithAboveDetails()
        {
            var accountClient = new RestApiClient("http://localhost:8080");
            restResponse = await accountClient.WithdrawAccount<DepositWithdrawAccountRequest>(depositWithdrawAccountRequest);
        }

    }
}
