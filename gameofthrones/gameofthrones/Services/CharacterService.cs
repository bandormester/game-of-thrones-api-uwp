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
    class CharacterService
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
        /// Get the list of Characters from API of Ice And Fire with Pagination
        /// </summary>
        /// <param name="pageNumber">Number of the wanted page</param>
        /// <param name="pageSize">Number of elements on a page</param>
        /// <returns></returns>
        public async Task<List<Character>> GetCharactersAsync(int pageNumber, int pageSize)
        {
            string url = "api/characters?page=" + pageNumber + "&pageSize=" + pageSize;
            Debug.WriteLine(url);
            return await GetAsync<List<Character>>(new Uri(serverUrl, url));
        }

        /// <summary>
        /// Gets a specific character from the API Ice And Fire 
        /// </summary>
        /// <param name="url"> The url address of the character </param>
        /// <returns></returns>
        public async Task<Character> GetCharacterAsync(string url)
        {
            return await GetAsync<Character>(new Uri(url));
        }
    }
}
