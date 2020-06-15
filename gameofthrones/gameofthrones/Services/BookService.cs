using gameofthrones.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gameofthrones.Services
{
    class BookService
    {
        private readonly Uri serverUrl = new Uri("https://www.anapioficeandfire.com");

        private async Task<T> GetAsync<T>(Uri uri)
        {

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = default(T);
                try
                {
                    result = JsonConvert.DeserializeObject<T>(json);
                }
                catch (WebException ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
                return result;
            }
        } 
        /// <summary>
        /// Get the list of the Books from API of Ice And Fire
        /// </summary>
        /// <returns></returns>
        public async Task<List<Book>> GetBooksAsync()
        {
            return await GetAsync<List<Book>>(new Uri(serverUrl, "api/books?pageSize=20"));
        }

        /// <summary>
        /// Gets a specific book from the API Ice And Fire 
        /// </summary>
        /// <param name="url"> The url address of the book </param>
        /// <returns></returns>
        public async Task<Book> GetBookAsync(string url)
        {
            return await GetAsync<Book>(new Uri(url));
        }


    }
}