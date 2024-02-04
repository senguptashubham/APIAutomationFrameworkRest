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
using TechTalk.SpecFlow;

namespace APIAutomationFrameworkRest.StepDefinitions
{
    [Binding]
    public class DeleteAccountApiStepDefs
    {
        private RestResponse restResponse;
        private ScenarioContext scenarioContext;
        private HttpStatusCode statusCode;

        public DeleteAccountApiStepDefs(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"User submit delete request for account number ""([^""]*)""")]
        public async Task GivenUserSubmitDeleteRequestForAccountNumber(string accountID)
        {
            var accountClient = new RestApiClient("http://localhost:8080");
            restResponse = await accountClient.DeleteAccount(accountID);
        }

        [Then(@"Verify the response code after deletion is ""([^""]*)""")]
        public void ThenVerifyTheResponseCodeAfterDeletionIs(string code)
        {
            statusCode = restResponse.StatusCode;
            int actual = (int)statusCode;
            int expected = Int32.Parse(code);
            Assert.AreEqual(expected, actual);
        }

        [Then(@"Verify no error is returned after deletion")]
        public void ThenVerifyNoErrorIsReturnedAfterDeletion()
        {
            var content = Helper.GetContent<DeleteAccountResponse>(restResponse);
            Assert.IsEmpty(content.Errors);
        }

        [Then(@"Verify the deletion success message for ""([^""]*)""")]
        public void ThenVerifyTheDeletionSuccessMessageFor(string accountID)
        {
            //Account <accountID> deleted successfully
            var content = Helper.GetContent<DeleteAccountResponse>(restResponse);
            var accountNo = content.Message.Split("Account ")[1].Split(" ")[0];
            Console.WriteLine("Deleted account no: " + accountNo);
        }

    }
}
