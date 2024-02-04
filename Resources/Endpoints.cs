using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationFrameworkRest.Resources
{
    public class Endpoints
    {
        public static readonly string CREATE_ACCOUNT = "/api/account/create";
        public static readonly string DELETE_ACCOUNT = "/api/account/delete/{accountID}";
        public static readonly string DEPOSIT_ACCOUNT = "/api/account/deposit";
        public static readonly string WITHDRAW_ACCOUNT = "/api/account/withdraw";
        public static readonly string DUMMY = "/users";
    }
}
