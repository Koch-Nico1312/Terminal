using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace AI;

public class Program
{
    public static async Task Main()
    {
        await AIChat.Start();
    }
}

public class AIChat
{
    public static async Task Start()
    {
        Console.Clear();
        Console.WriteLine("Ollama AI (\"exit\" zum Beenden)\n");

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

            try
            {
                var response = await client.PostAsync(
                    "http://localhost:11434/api/generate",
                    content
                );

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"\n[Fehler] HTTP {((int)response.StatusCode)} - {response.ReasonPhrase}\n");
                    continue;
                }

                var resultJson = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(resultJson))
                {
                    Console.WriteLine("\n[Fehler] Leere Antwort vom Server.\n");
                    continue;
                }

                using JsonDocument doc = JsonDocument.Parse(resultJson);

                if (!doc.RootElement.TryGetProperty("response", out var responseProp))
                {
                    Console.WriteLine("\n[Fehler] Feld \"response\" in der JSON-Antwort nicht gefunden.\n");
                    Console.WriteLine("Rohantwort:\n" + resultJson + "\n");
                    continue;
                }

                string? answer = responseProp.GetString();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine("\n[Hinweis] Antwort ist leer.\n");
                    continue;
                }

                Console.WriteLine("\nAI: " + answer + "\n");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\n[Verbindungsfehler] Konnte Ollama nicht erreichen.");
                Console.WriteLine("Läuft der Server auf http://localhost:11434 ?\n");
                Console.WriteLine($"Details: {ex.Message}\n");
            }
            catch (JsonException ex)
            {
                Console.WriteLine("\n[JSON-Fehler] Antwort konnte nicht gelesen werden.");
                Console.WriteLine($"Details: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n[Unbekannter Fehler]");
                Console.WriteLine($"Details: {ex.Message}\n");
            }
        }
    }
}
