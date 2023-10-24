using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace APIAssignment.Helper
{
    public  class APIhelper
    {
        private RestClient client;
        private RestRequest request;

        public RestClient SetURL()
        {        
            client = new RestClient();
            return client;
        }

        public RestRequest GetRequest(string baseurl,string endpoint)
        {
            var url = Path.Combine(baseurl, endpoint);
            request = new RestRequest(url,Method.Get);
            request.AddHeader("Accept", "application/json");
            return request;

        }

        public RestRequest PostRequest(string baseurl,string endpoint,string body)
        {
            var url = Path.Combine(baseurl, endpoint);
            request = new RestRequest(url, Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddBody(body); ;
            return request;
        }

        public RestRequest PutRequest(string baseurl, string endpoint,string body)
        {
            var url = Path.Combine(baseurl, endpoint);
            request = new RestRequest(url, Method.Put);
            request.AddHeader("Accept", "application/json");
            request.AddBody(body);
            return request;
        }

        public RestRequest PatchRequest(string baseurl, string endpoint,string body)
        {
            var url = Path.Combine(baseurl, endpoint);
            request = new RestRequest(url, Method.Patch);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json",body,ParameterType.RequestBody);
            return request;
        }


        public RestResponse GetResponse(RestClient restClient,RestRequest request)
        {
            return restClient.Execute(request);
        }

        



    }
}
