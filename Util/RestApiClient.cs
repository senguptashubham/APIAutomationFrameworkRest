using APIAutomationFrameworkRest.Resources;
using RestSharp;

namespace APIAutomationFrameworkRest.Util
{
    public class RestApiClient : IRestApiClient, IDisposable
    {
        readonly RestClient client;
        public RestApiClient(string baseUrl)
        {
            var options = new RestClientOptions(baseUrl);
            client = new RestClient(options);
        }
        public async Task<RestResponse> CreateAccount<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.CREATE_ACCOUNT, Method.Post);
            request.AddBody(payload);
            return await client.ExecuteAsync<T>(request);
        }

        public async Task<RestResponse> DeleteAccount(string accountNumber) 
        {
            var request = new RestRequest(Endpoints.DELETE_ACCOUNT, Method.Delete);
            request.AddUrlSegment(accountNumber,accountNumber);
            return await client.ExecuteAsync(request);
        }

        public async Task<RestResponse> DepositAccount<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.DEPOSIT_ACCOUNT, Method.Put);
            request.AddBody(payload);
            return await client.ExecuteAsync<T>(request);
        }

        public void Dispose()
        {
            client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<RestResponse> WithdrawAccount<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.WITHDRAW_ACCOUNT, Method.Put);
            request.AddBody(payload);
            return await client.ExecuteAsync<T>(request);
        }

        public async Task<RestResponse> Dummy<T>(T payload) where T:class
        {
            var request = new RestRequest(Endpoints.DUMMY, Method.Post);
            request.AddBody(payload);
            return await client.ExecuteAsync<T>(request);
        }
    }
}
