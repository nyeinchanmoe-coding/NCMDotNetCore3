using NCMDotNetCore.ConsoleAppHttpClientExamples;
using Newtonsoft.Json;

//Console.WriteLine("Hello, World!");

//HttpClient client = new HttpClient();
//var response = await client.GetAsync("https://localhost:7271/api/blog");
//if (response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync();
//    List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;

//    foreach (var item in lst)
//    {
//        Console.WriteLine($"BlogId => {JsonConvert.SerializeObject(item.BlogId)}");
//        Console.WriteLine($"BlogTitle => {JsonConvert.SerializeObject(item.BlogTitle)}");
//        Console.WriteLine($"BlogAuthor => {JsonConvert.SerializeObject(item.BlogAuthor)}");
//        Console.WriteLine($"BlogContent => {JsonConvert.SerializeObject(item.BlogContent)}");
//        Console.WriteLine("*************************");
//    }
//    Console.ReadKey();

//}
HttpClientExamplt httpClientExamplt = new HttpClientExamplt();
await httpClientExamplt.run();