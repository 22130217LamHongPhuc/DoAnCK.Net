using API.Net.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace Web.net.Service
{
    public class OrderService
    {

        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Gửi order lên Web API
        public async Task<bool> CreateOrderAsync(Order order)
        {
            var jsonOrder = JsonConvert.SerializeObject(order);
            var content = new StringContent(jsonOrder, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5009/order", content); // URL của Web API

            Console.WriteLine($"Status Code: {response.StatusCode}");
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Content: {responseContent}");

            return response.IsSuccessStatusCode;
        }

    }
}
