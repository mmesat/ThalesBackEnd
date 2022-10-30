using System.Text.Json;
using ThalesBack.Entity;
using System.Net;

namespace ThalesBack.Data
{
    public class EmployeesData
    {
        private readonly IConfiguration configuration;

        public EmployeesData(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<ResponseEmployees> GetAll()
        {
            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(configuration["UrlEmployees"]))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonSerializer.Deserialize<ResponseEmployees>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return (new ResponseEmployees
                        {
                            status = "Error",
                            message = response.StatusCode.ToString()
                        }); ;
                    }
                }
            }
        }

        public async Task<ResponseEmployee> GetEmployee(int id)
        {

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(configuration["UrlEmployee"]+ id))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonSerializer.Deserialize<ResponseEmployee>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return (new ResponseEmployee
                        {
                            status = "Error",
                            message = response.StatusCode.ToString()
                        }); ;
                    }
                }
            }
        }
    }
}
