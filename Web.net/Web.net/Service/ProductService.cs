using API.Net.Models;
using System.Text.Json;

namespace Web.net.Service
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }




        public async Task<List<Product>> GelAllProduct()
        {
           
            string url = "http://localhost:5009/products";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
              
                var json = await response.Content.ReadAsStringAsync();

                Console.WriteLine(json);

             
               var products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // khong phan biet hoa thuong
                });

                if(products !=null)
                {
                    return products;
                }
            }

            return new List<Product>();
           
        }


        public async Task<List<Product>> GetProductHighestDate()
        {

            string url = "http://localhost:5009/products/new";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                var json = await response.Content.ReadAsStringAsync();

                Console.WriteLine(json);


                var products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // khong phan biet hoa thuong
                });

                if (products != null)
                {
                    return products;
                }
            }

            return new List<Product>();

        }


        public async Task<List<Product>> GetProductHighestPrice()
        {

            string url = "http://localhost:5009/products/highest_price";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                var json = await response.Content.ReadAsStringAsync();

                Console.WriteLine(json);


                var products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // khong phan biet hoa thuong
                });

                if (products != null)
                {
                    return products;
                }
            }

            return new List<Product>();

        }


        public async Task<List<Product>> GetProductBestSeller()
        {

            string url = "http://localhost:5009/products/best_seller";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                var json = await response.Content.ReadAsStringAsync();

                Console.WriteLine(json);


                var products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // khong phan biet hoa thuong
                });

                if (products != null)
                {
                    return products;
                }
            }
            return new List<Product>();

        }


    }
}
