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
        public void AddDataIntoJsonServer(Employeedata emp)
        {
            //Passing the post method 
            RestRequest request = new RestRequest("/Employee", Method.POST);
            //creating the object
            JsonObject json = new JsonObject();
            json.Add("id", emp.id);
            json.Add("name", emp.Name);
            json.Add("salary", emp.Salary);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //Convert the json object to list
            var res = JsonConvert.DeserializeObject<Employeedata>(response.Content);
            Console.WriteLine("" + res.id + "Added");
        }
        public void AddMultipleDataIntoServer(List<Employeedata> employee)
        {
            foreach (var e in employee)
            {
                AddDataIntoJsonServer(e);
            }
        }
        public bool UpdateDetailInJsonServer(Employeedata emp)
        {
            //Passing the put method 
            RestRequest request = new RestRequest("/Employee/" + emp.id, Method.PUT);
            JsonObject json = new JsonObject();
            json.Add("id", emp.id);
            json.Add("name", emp.Name);
            json.Add("salary", emp.Salary);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //Convert the json object to list
            var res = JsonConvert.DeserializeObject<Employeedata>(response.Content);
            return response.IsSuccessful;
        }
        public bool DeleteEmployeeData(int id)
        {
            //Passing the delete method 
            RestRequest request = new RestRequest("/Employee/" + id, Method.DELETE);
            IRestResponse response = client.Execute(request);
            return response.IsSuccessful;
        }
    }
}
