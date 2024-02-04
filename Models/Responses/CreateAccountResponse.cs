using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationFrameworkRest.Models.Responses
{
    public class CreateAccountResponse
    {
        public Data Data { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
    }

    public class Data
    {
        public int NewBalance { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
    }

}
