using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIAssignment.Helper;
using APIAssignment.Models;
using APITestAssignment;
using APITestAssignment.APIHelper;
using APITestAssignment.Models;
using RestSharp;

namespace APIAssignment.Test
{
    public class APIResponseTest
    {
        private APIhelper helper;
        public APIResponseTest()
        {
            helper = new APIhelper();
        }
        public RestResponse GetUsers(string baseurl)
        {
           
            var client = helper.SetURL();
            var request = helper.GetRequest(baseurl,"api/users?page=2");
            request.RequestFormat = DataFormat.Json;
            var response =helper.GetResponse(client, request);
            return response;

        }

        public RestResponse GetSingleUser(dynamic  baseurl)
        {

            var client = helper.SetURL();
            var request = helper.GetRequest(baseurl, "api/users/2");
            request.RequestFormat = DataFormat.Json;
            var response = helper.GetResponse(client, request);
            return response;

        }

        public RestResponse CreateUsers(string baseurl, dynamic payload)
        {
            var client = helper.SetURL();
            var jsonstring = HandelData.SerializeJsonString(payload);
            var request = helper.PostRequest(baseurl,"api/users", jsonstring);
            var response = helper.GetResponse(client,request);
            return response;
        }

        public RestResponse PutUsers(string baseurl,dynamic payload)
        {
            var client = helper.SetURL();
            var jsonstring = HandelData.SerializeJsonString(payload);
            var request = helper.PutRequest(baseurl,"api/users/2", jsonstring);
            var response = helper.GetResponse(client, request);
            return response;
        }

        public RestResponse PatchUsers(string baseurl, dynamic payload)
        {
            var client = helper.SetURL();
            var jsonstring = HandelData.SerializeJsonString(payload);
            var request = helper.PatchRequest(baseurl, "api/users/2", jsonstring);
            var response = helper.GetResponse(client, request);
            return response;
        }
    }
}
