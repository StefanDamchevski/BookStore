using BookStoreDashboard.Models;
using BookStoreDashboard.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookStoreDashboard.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly string bookStoreBaseUrl;
        private readonly string authSchema;
        private readonly string apiKey;

        public BookRepository(IConfiguration configuration)
        {
            bookStoreBaseUrl = configuration["BookStoreApi:BaseUrl"];
            authSchema = configuration["BookStoreApi:AuthSchema"];
            apiKey = configuration["BookStoreApi:ApiKey"];
        }
        public async Task<bool> Create(Book book)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authSchema,apiKey);

            HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync<Book>($"{bookStoreBaseUrl}/api/books", book);

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

            HttpResponseMessage httpResponse = await httpClient.GetAsync($"{bookStoreBaseUrl}/api/books");

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

            HttpResponseMessage httpResponse = await httpClient.GetAsync($"{bookStoreBaseUrl}/api/books/{id}");

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

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authSchema, apiKey);

            HttpResponseMessage httpResponse = await httpClient.PutAsJsonAsync<Book>($"{bookStoreBaseUrl}/api/books", book);

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

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authSchema, apiKey);

            HttpResponseMessage httpResponse = await httpClient.DeleteAsync($"{bookStoreBaseUrl}/api/books/{id}");
        }
    }
}