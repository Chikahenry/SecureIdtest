using static System.Net.WebRequestMethods;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProductMS.SyncMS;

public class SyncOrders
{

    public async List<Object> GetOrders()
    {
        var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://microservice2-url");
            httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var token = "your-generated-jwt-token"; 
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await httpClient.GetAsync("/api/order/get-orders");
        if (response.IsSuccessStatusCode)
        {
            // Process the response
            return response.Content.ReadAsStringAsync().FromJson<List<Object>();
        }
        else
        {
            // Handle errors
            return null;
        }




    }

}