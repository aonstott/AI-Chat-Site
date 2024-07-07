using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AiApp.OllamaCaller
{

    public class OllamaCaller
    {
        public async Task CallApi()
        {
            string url = "http://localhost:11434/api/generate";
            string json = @"{
            ""model"": ""wey"",
            ""prompt"": ""q onda wey""
            }";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Console.WriteLine("Sending POST request to " + url);
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    Console.WriteLine("Response from server: " + response.StatusCode);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine(responseBody);

                    // Print the response in a more readable way
                List<string> responses = new List<string>();

                // Split responseBody by newline character '\n'
                string[] lines = responseBody.Split("\n");

                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        try
                        {
                            Response? res = JsonConvert.DeserializeObject<Response>(line);
                            if (res != null)
                            {
                                responses.Add(res.response);
                            }
                            else
                            {
                                Console.WriteLine($"Failed to deserialize line: {line}");
                            }
                        }
                        catch (JsonException ex)
                        {
                            Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                        }
                    }
                }

                // Print the collected responses as a single string
                Console.WriteLine(string.Join("", responses));
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    if (e.InnerException != null)
                    {
                        Console.WriteLine("Inner Exception :{0} ", e.InnerException.Message);
                    }
                }
            }
        }
    }
}