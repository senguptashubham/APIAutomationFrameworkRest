using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationFrameworkRest.Models.Responses
{
    public class DepositWithdrawAccountResponse
    {
        public Data DataDeposit { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
    }

    public class DataDeposit
    {
        public string AccountNumber { get; set; }
        public int NewBalance { get; set; }
    }

}
