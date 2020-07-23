using BookStoreDashboard.Models;
using BookStoreDashboard.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookStoreDashboard.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly string bookStoreBaseUrl;
        private readonly string authSchema;
        private readonly string apiKey;

        public OrderRepository(IConfiguration configuration)
        {
            bookStoreBaseUrl = configuration["BookStoreApi:BaseUrl"];
            authSchema = configuration["BookStoreApi:AuthSchema"];
            apiKey = configuration["BookStoreApi:ApiKey"];
        }
        public async Task<List<Order>> GetAll()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authSchema, apiKey);

            HttpResponseMessage httpResponse = await httpClient.GetAsync($"{bookStoreBaseUrl}/api/orders");

            List<Order> orders = new List<Order>();

            if (httpResponse.IsSuccessStatusCode)
            {
                String response = await httpResponse.Content.ReadAsStringAsync();
                orders = JsonConvert.DeserializeObject<List<Order>>(response);
            }

            return orders;
        }

        public async Task<Order> GetById(int id)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authSchema, apiKey);

            HttpResponseMessage httpResponse = await httpClient.GetAsync($"{bookStoreBaseUrl}/api/orders/{id}");

            Order order = new Order();

            if (httpResponse.IsSuccessStatusCode)
            {
                String response = await httpResponse.Content.ReadAsStringAsync();
                order = JsonConvert.DeserializeObject<Order>(response);
            }
            return order;
        }

        public async Task<bool> Update(Order order)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authSchema, apiKey);

            HttpResponseMessage httpResponse = await httpClient.PutAsJsonAsync($"{bookStoreBaseUrl}/api/orders", order);

            return CheckIfFailed(httpResponse);
        }

        private static bool CheckIfFailed(HttpResponseMessage httpResponse)
        {
            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
