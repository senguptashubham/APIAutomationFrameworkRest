using APIAutomationFrameworkRest.Models.Requests;
using APIAutomationFrameworkRest.Models.Responses;
using APIAutomationFrameworkRest.Util;
using Gherkin.Ast;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace APIAutomationFrameworkRest.StepDefinitions
{
    [Binding]
    public class CreateAccountApiStepDefs
    {
        private CreateAccountRequest createAccountRequest;
       
        private RestResponse restResponse;
        private ScenarioContext scenarioContext;
        private HttpStatusCode statusCode;

        public CreateAccountApiStepDefs(ScenarioContext scenarioContext, CreateAccountRequest createAccountRequest)
        {
            this.scenarioContext = scenarioContext;
            this.createAccountRequest = createAccountRequest;
            
        }


        [Given(@"Account Initial Balance is ""([^""]*)""")]
        public void GivenAccountInitialBalanceIs(string bal)
        {
            int balance = Int32.Parse(bal.Split("$")[1]);
            createAccountRequest.InitialBalance = balance;
        }

        [Given(@"Account name is ""([^""]*)""")]
        public void GivenAccountNameIs(string name)
        {
            createAccountRequest.AccountName = name;
        }

        [Given(@"Address is ""([^""]*)""")]
        public void GivenAddressIs(string address)
        {
            createAccountRequest.Address = address;
        }

        [When(@"User create a new account with above details")]
        public async Task WhenUserCreateANewAccountWithAboveDetails()
        {
            var accountClient = new RestApiClient("http://localhost:8080");
            restResponse = await accountClient.CreateAccount<CreateAccountRequest>(createAccountRequest);
        }

        [Then(@"Verify the response code is ""([^""]*)""")]
        public void ThenVerifyTheResponseCodeIs(string code)
        {
            statusCode = restResponse.StatusCode;
            int actual = (int)statusCode;
            int expected = Int32.Parse(code);
            Assert.AreEqual(expected, actual);
        }

        [Then(@"Verify no error is returned")]
        public void ThenVerifyNoErrorIsReturned()
        {
            var content = Helper.GetContent<CreateAccountResponse>(restResponse);
            Assert.IsEmpty(content.Errors);
        }

        [Then(@"Verify the creation success message and get new account number")]
        public void ThenVerifyTheCreationSuccessMessageAndGetNewAccountNumber()
        {
            //Account X123 created successfully
            var content = Helper.GetContent<CreateAccountResponse>(restResponse);
            var accountNo = content.Message.Split("Account ")[1].Split(" ")[0];
            Console.WriteLine("New account no: "+ accountNo);
        }


        [Then(@"Verify the account details ""([^""]*)"" and ""([^""]*)"" are correct in the response")]
        public void ThenVerifyTheAccountDetailsAndAreCorrectInTheResponse(string initialBalance, string accountName)
        {
            int balance = Int32.Parse(initialBalance.Split("$")[1]);
            var content = Helper.GetContent<CreateAccountResponse>(restResponse);
            Assert.AreEqual(balance, content.Data.NewBalance);
            Assert.AreEqual(accountName, content.Data.AccountName);
        }

    }
}
