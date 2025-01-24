using System.Text.Json;

namespace SemanticAspire.Web;

public class ChatApiClient(HttpClient httpClient)
{
    public async Task<PromptResponse> PostPromptAsync(string prompt, CancellationToken cancellationToken = default)
    {
        var requestBody = new PromptRequest(prompt);
        var response = await httpClient.PostAsJsonAsync("/api/chat", requestBody);

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var responseObject = JsonSerializer.Deserialize<PromptResponse>(responseBody);

        return responseObject ?? new PromptResponse(prompt, "");
    }
}

public record PromptRequest(string Prompt);
public record PromptResponse(string prompt, string response);
