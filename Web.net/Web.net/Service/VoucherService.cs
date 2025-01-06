using API.Net.Models;
using System.Text.Json;

namespace Web.net.Service
{
    public class VoucherService
    {

        private readonly HttpClient _httpClient;

        public VoucherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<Voucher>> GelVoucher()
        {

            string url = "http://localhost:5009/vouchers";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                var json = await response.Content.ReadAsStringAsync();

                Console.WriteLine(json);


                var products = JsonSerializer.Deserialize<List<Voucher>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // khong phan biet hoa thuong
                });

                if (products != null)
                {
                    return products;
                }
            }

            return new List<Voucher>();

        }

        public async Task<Voucher> GetVoucherByCondition(string discountCode, double total)
        {

            string url = "http://localhost:5009/vouchers/voucher-condition?code="+ discountCode + "&totalPrice="+ total;

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                var json = await response.Content.ReadAsStringAsync();

                Console.WriteLine(json);


                var voucher = JsonSerializer.Deserialize<Voucher>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // khong phan biet hoa thuong
                });

                if (voucher != null)
                {
                    return voucher;
                }
                else
                {
                    return null;
                }
            }

            return null;

        }
    }
}
