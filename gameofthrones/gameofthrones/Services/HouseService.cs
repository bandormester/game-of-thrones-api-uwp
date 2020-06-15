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
    class HouseService
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
        /// Get the list of Houses from API of Ice And Fire with Pagination
        /// </summary>
        /// <param name="pageNumber">Number of the wanted page</param>
        /// <param name="pageSize">Number of elements on a page</param>
        /// <returns></returns>
        public async Task<List<House>> GetHousesAsync(int pageNumber, int pageSize)
        {
            string url = "api/houses?page=" + pageNumber + "&pageSize=" + pageSize;
            Debug.WriteLine(url);
            return await GetAsync<List<House>>(new Uri(serverUrl, url));
        }

        /// <summary>
        /// Gets a specific house from the API Ice And Fire 
        /// </summary>
        /// <param name="url">The url address of the house</param>
        /// <returns></returns>
        public async Task<House> GetHouseAsync(string url)
        {
            return await GetAsync<House>(new Uri(url));
        }

    }
}
