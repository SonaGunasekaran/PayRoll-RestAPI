using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollRestAPI
{
    public class PayRollJson
    {
        RestClient client;
        public PayRollJson()
        {
            client = new RestClient("http://localhost:3000");
        }
        IRestResponse GetAllEmployee()
        {
            RestRequest request = new RestRequest("/Employee");
            //Pass the request
            IRestResponse response = client.Execute(request);
            return response;
        }
        public List<Employeedata> ReadServer()
        {
            IRestResponse response = GetAllEmployee();
            //Convert the json object to list
            var res = JsonConvert.DeserializeObject<List<Employeedata>>(response.Content);
            return res;
        }
    }
}
