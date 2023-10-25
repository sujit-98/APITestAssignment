using System;
using APIAssignment.Models;
using APIAssignment.Test;
using APITestAssignment.APIHelper;
using APITestAssignment.Models;
using NUnit.Framework;
using RestSharp;
using System.Configuration;
using TechTalk.SpecFlow;
using System.Security.Policy;
using Newtonsoft.Json;

namespace APITestAssignment.StepDefinitions
{
    [Binding]
    public class APITestStepDefinitions1
    {
        //private const string BASE_URL = "https://reqres.in/";
        static string jsonFilePath = "C:\\Users\\hp\\source\\repos\\APITestAssignment\\specflow.json";
        static string file = File.ReadAllText(jsonFilePath);
        static dynamic testData = JsonConvert.DeserializeObject<dynamic>(file);
        static string BASE_URL = testData.url;
        APIResponseTest api = new APIResponseTest();
        private readonly CreateUserRequest createUserRequest;
        private RestResponse response;


        public APITestStepDefinitions1(CreateUserRequest createUserRequest)
        {
            this.createUserRequest = createUserRequest;
        }
       

        [Given(@"Input name ""(.*)""")]
        public void GivenInputName(string name)
        {
            
            createUserRequest.name = name;
        }

        [Given(@"Input Job ""(.*)""")]
        public void GivenInputJob(string job)
        {
            createUserRequest.job = job;
        }

        [When(@"Send request to use")]
        public void WhenSendRequestToUse()
        {
            response= api.CreateUsers(BASE_URL, createUserRequest);
        }

        [When(@"Send request to update")]
        public void WhenSendRequestToUpdate()
        {
            response = api.PutUsers(BASE_URL, createUserRequest);
        }

        [When(@"Send request to Patch")]
        public void WhenSendRequestToPatch()
        {
            response = api.PatchUsers(BASE_URL, createUserRequest);
        }


        [Then(@"Validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            var content = HandelData.GetContent<CreateUserRes>(response);
            Assert.AreEqual( createUserRequest.name, content.name);
        }

        [Then(@"Validate user is updated")]
        public void ThenValidateUserIsUpdated()
        {
            var content = HandelData.GetContent<CreateUserRes>(response);
            Assert.AreEqual(createUserRequest.name, content.name);
        }

       

        [Then(@"Validate user is patched")]
        public void ThenValidateUserIsPatched()
        {
            var content = HandelData.GetContent<CreateUserRes>(response);
            Assert.AreEqual(createUserRequest.name, content.name);
        }

        [Then(@"Validate Error Response")]
        public void ThenValidateErrorResponse()
        {
            Assert.AreEqual(400, response.StatusCode);
        }




    }


}
