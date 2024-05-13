using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCMDotNetCore.ConsoleAppHttpClientExamples
{
    internal class HttpClientExamplt
    {
        HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7271") };
        string _endpoint = "/api/blog";

        public async Task run()
        {
            await Read();
        }

        public async Task Read()
        {
            HttpResponseMessage response = await _client.GetAsync(_endpoint);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;

                foreach (var item in lst)
                {
                    Console.WriteLine($"BlogId => {JsonConvert.SerializeObject(item.BlogId)}");
                    Console.WriteLine($"BlogTitle => {JsonConvert.SerializeObject(item.BlogTitle)}");
                    Console.WriteLine($"BlogAuthor => {JsonConvert.SerializeObject(item.BlogAuthor)}");
                    Console.WriteLine($"BlogContent => {JsonConvert.SerializeObject(item.BlogContent)}");
                    Console.WriteLine("*************************");
                }
                Console.ReadKey();
            }
        }
    }   
}
