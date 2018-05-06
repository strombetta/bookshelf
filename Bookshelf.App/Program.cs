using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Bookshelf;

namespace Bookshelf.App
{
    class Program
    {
        private static HttpClient _client = new HttpClient();
        
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            _client.BaseAddress = new Uri("http://localhost:5000/api/");
            var response = await _client.GetAsync("Books");
            if(response.IsSuccessStatusCode)
            {
                var book = await response.Content.ReadAsStringAsync();
                Console.WriteLine(book);
            }
        }
    }
}
