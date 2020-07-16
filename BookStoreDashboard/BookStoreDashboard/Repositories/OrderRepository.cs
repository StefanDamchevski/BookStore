using BookStoreDashboard.Models;
using BookStoreDashboard.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookStoreDashboard.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<List<Order>> GetAll()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.GetAsync("https://localhost:44342/api/orders");

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

            HttpResponseMessage httpResponse = await httpClient.GetAsync($"https://localhost:44342/api/orders/{id}");

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

            HttpResponseMessage httpResponse = await httpClient.PutAsJsonAsync("https://localhost:44342/api/orders", order);

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
