using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAutomationFrameworkRest.Models.Responses
{
    public class DeleteAccountResponse
    {
        public Data Data { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
    }

}
