using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace AI;

public class AIChat
{
    public static async Task Start()
    {
        Console.Clear();
        Console.WriteLine("Ollama AI (exit zum Beenden)\n");

        using HttpClient client = new HttpClient();

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input.ToLower() == "exit")
                break;

            var request = new
            {
                model = "llama3",
                prompt = input,
                stream = false
            };

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                "http://localhost:11434/api/generate",
                content
            );

            var resultJson = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(resultJson);
            string answer = doc.RootElement.GetProperty("response").GetString()!;

            Console.WriteLine("\nAI: " + answer + "\n");
        }
    }
}
