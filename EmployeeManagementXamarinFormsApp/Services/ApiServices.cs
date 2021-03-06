using EmployeeManagementXamarinFormsApp.Helpers;
using EmployeeManagementXamarinFormsApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementXamarinFormsApp.Services
{
    public class ApiServices
    {
        //***Register Button
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("http://172.20.32.1:800/api/Account/Register", content);
            return response.IsSuccessStatusCode;
        }

        //***Login Button
        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "http://172.20.32.1:800/Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            //var content = await response.Content.ReadAsStringAsync();
            //Debug.WriteLine(content);

            var jwt = await response.Content.ReadAsStringAsync();
            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);
            var accessToken = jwtDynamic.Value<string>("access_token");

            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
            Settings.AccessTokenExpiration = accessTokenExpiration;

            Debug.WriteLine(jwt);
            return accessToken;
        }

        //***Loads All Employees
        public async Task<List<EmployeeBindingModel>> GetEmployeesAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = await client.GetStringAsync("http://172.20.32.1:800/api/Employees");
            var employees = JsonConvert.DeserializeObject<List<EmployeeBindingModel>>(json);
            return employees;
        }

        //***Adding New Employees
        public async Task PostEmployeesAsync(EmployeeBindingModel employeeBindingModel,string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = JsonConvert.SerializeObject(employeeBindingModel);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            /*var response = */await client.PostAsync("http://172.20.32.1:800/api/Employees", content);
        }

        //***Putting (Updating) a Employee
        public async Task PutEmployeeAsync(EmployeeBindingModel employeeBindingModel, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = JsonConvert.SerializeObject(employeeBindingModel);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync("http://172.20.32.1:800/api/Employees/'"+employeeBindingModel.EmployeeID+"'", content);
            Debug.WriteLine(response);
        }

        //***Deleting a Employee
        public async Task DeleteEmployeeAsync(int id, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await client.DeleteAsync("http://172.20.32.1:800/api/Employees/'"+id+"'");
            Debug.WriteLine(response);
        }

        //***Loads all Employees containing the "keyword" in their name and surname.
        public async Task<List<EmployeeBindingModel>> SearchEmployeesAsync(string keyword, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = await client.GetStringAsync("http://172.20.32.1:800/api/Employees/Search/'"+keyword+"'");
            var employees = JsonConvert.DeserializeObject<List<EmployeeBindingModel>>(json);
            return employees;
        }
    }
}
