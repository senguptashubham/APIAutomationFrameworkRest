using APIAutomationFrameworkRest.Models.Requests;
using RestSharp;

namespace APIAutomationFrameworkRest.Util
{
    public interface IRestApiClient
    {
        Task<RestResponse> CreateAccount<T>(T payload) where T:class;
        Task<RestResponse> DeleteAccount(string accountNumber);
        Task<RestResponse> DepositAccount<T>(T payload) where T:class;
        Task<RestResponse> WithdrawAccount<T>(T payload) where T:class;
        Task<RestResponse> Dummy<T>(T payload) where T : class;
    }
}
