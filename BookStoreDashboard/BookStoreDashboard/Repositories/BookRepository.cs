using BookStoreDashboard.Models;
using BookStoreDashboard.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookStoreDashboard.Repositories
{
    public class BookRepository : IBookRepository
    {
        public async Task<bool> Create(Book book)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync<Book>($"https://localhost:44342/api/books", book);

            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Book>> GetAll()
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.GetAsync("https://localhost:44342/api/books");

            List<Book> books = new List<Book>();

            if (httpResponse.IsSuccessStatusCode)
            {
                String resonse = await httpResponse.Content.ReadAsStringAsync();
                books = JsonConvert.DeserializeObject<List<Book>>(resonse);
            }

            return books;
        }

        public async Task<Book> GetById(int id)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.GetAsync($"https://localhost:44342/api/books/{id}");

            Book book = new Book();

            if (httpResponse.IsSuccessStatusCode)
            {
                String response = await httpResponse.Content.ReadAsStringAsync();
                book = JsonConvert.DeserializeObject<Book>(response);
            }

            return book;
        }

        public async Task<bool> Update(Book book)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.PutAsJsonAsync<Book>($"https://localhost:44342/api/books", book);

            if (httpResponse.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task Delete(int id)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponse = await httpClient.DeleteAsync($"https://localhost:44342/api/books/{id}");
        }
    }
}