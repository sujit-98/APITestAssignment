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
using RestSharp;
using APITestAssignment.APIHelper;

namespace APITestAssignment.StepDefinitions
{
    [Binding]
    public class APITestStepDefinitions2
    {
        private readonly Users users;
        private const string BASE_URL = "https://reqres.in/";
        APIResponseTest api = new APIResponseTest();
        public RestResponse response;
        public APITestStepDefinitions2(Users users)
        {
            this.users = users;
        }

        [Given(@"baseurl")]
        public void GivenBaseurl()
        {
            response = api.GetUsers(BASE_URL);

        }


        [When(@"Get request to use")]
        public void WhenGetRequestToUse()
        {
            response = api.GetUsers(BASE_URL);
        }


        [Then(@"Validate list of users")]
        public void ThenValidateListOfUsers()
        {
            var content = HandelData.GetContent<Users>(response);

            Assert.True(ContentVerification(content));
        }

        private static bool ContentVerification (Users data)
        {
            bool flag = false;
            foreach (var res in data.data)
            {
                if (res.first_name.Equals("George"))
                {
                    flag= true;
                    return flag;
                }
                else
                {
                    flag= false;
                    continue;
                }

            }
            return flag;
        }
    }
}
