Console.WriteLine("Hello, World!");

HttpClient client = new HttpClient();
//HttpResponseMessage response = await client.GetAsync("https://localhost:7271/api/blog");
var  response = await client.GetAsync("https://localhost:7271/api/blog");
if (response.IsSuccessStatusCode)
{
    string jsonStr = await response.Content.ReadAsStringAsync();
    Console.WriteLine(jsonStr);
}