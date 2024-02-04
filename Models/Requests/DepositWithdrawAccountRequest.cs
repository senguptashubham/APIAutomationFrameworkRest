using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationFrameworkRest.Models.Requests
{
    public class DepositWithdrawAccountRequest
    {
        public string AccountNumber { get; set; }
        public int Amount { get; set; }
    }

}
