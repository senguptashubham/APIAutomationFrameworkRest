using APIAutomationFrameworkRest.Models.Requests;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APIAutomationFrameworkRest.Util
{
    public class Helper
    {
        
        
        private static RestResponse restResponse;

        
        public static T GetContent<T>(RestResponse response)
        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }

        
    }
}
