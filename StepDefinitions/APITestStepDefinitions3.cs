using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIAssignment.Models;
using APIAssignment.Test;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using APITestAssignment.Models;
using Newtonsoft.Json;
using RestSharp;
using APITestAssignment.APIHelper;

namespace APITestAssignment.StepDefinitions
{
    [Binding]
    public class APITestStepDefinitions3
    {
        private readonly SingleUser user;
        private const string BASE_URL = "https://reqres.in/";
        APIResponseTest api = new APIResponseTest();
        public RestResponse response;
        public APITestStepDefinitions3(SingleUser user)
        {
            this.user = user;
        }



        [When(@"Get request to use for single user")]
        public void WhenGetRequestToUseForSingleUser()
        {      
         
            response = api.GetSingleUser(BASE_URL);
        }


        [Then(@"Validate  user data")]
        public void ThenValidateUserData()
        {
            var content = HandelData.GetContent<SingleUser>(response);

            Assert.AreEqual("Janet", content.data.first_name);
        }

    }
}
