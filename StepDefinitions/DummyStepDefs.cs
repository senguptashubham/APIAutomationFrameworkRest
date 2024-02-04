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
    public class DummyStepDefs
    {
        private DummyRequest dummyRequest;
        private RestResponse restResponse;
        private ScenarioContext scenarioContext;
        private HttpStatusCode statusCode;

        public DummyStepDefs(DummyRequest dummyRequest, ScenarioContext scenarioContext)
        {
            this.dummyRequest = dummyRequest;
            this.scenarioContext = scenarioContext;
        }

        [Given(@"Dummy Account Initial Balance is ""([^""]*)""")]
        public void GivenDummyAccountInitialBalanceIs(string initialBalance)
        {
            int balance = Int32.Parse(initialBalance.Split("$")[1]);
            dummyRequest.InitailBalance = balance;
        }

        [Given(@"Dummy Account name is ""([^""]*)""")]
        public void GivenDummyAccountNameIs(string name)
        {
            dummyRequest.AccountName = name;
        }

        [Given(@"Dummy Account Address is ""([^""]*)""")]
        public void GivenDummyAccountAddressIs(string address)
        {
            dummyRequest.Address = address;
        }

        [When(@"User create a Dummy Account with above details")]
        public async Task WhenUserCreateADummyAccountWithAboveDetails()
        {
            var dummyClient = new RestApiClient("http://localhost:3000");
            restResponse = await dummyClient.Dummy<DummyRequest>(dummyRequest);
        }

        [Then(@"Verify the dummy response code is ""([^""]*)""")]
        public void ThenVerifyTheDummyResponseCodeIs(string code)
        {
            statusCode = restResponse.StatusCode;
            int actual = (int)statusCode;
            int expected = Int32.Parse(code);
            Assert.AreEqual(expected,actual);
        }

        [Then(@"Verify the dummy account details ""([^""]*)"" and ""([^""]*)"" are correct in the response")]
        public void ThenVerifyTheDummyAccountDetailsAndAreCorrectInTheResponse(string initialBalance, string accountName)
        {
            int balance = Int32.Parse(initialBalance.Split("$")[1]);
            var content = Helper.GetContent<DummyResponse>(restResponse);
            Assert.AreEqual(balance, content.InitailBalance);
            Assert.AreEqual(accountName, content.AccountName);
        }

    }
}
