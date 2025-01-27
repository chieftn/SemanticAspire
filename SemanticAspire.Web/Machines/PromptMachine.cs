namespace SemanticAspire.Web;
public class PromptMachine(ChatApiClient chatApiClient)
{
    public Guid Id { get; }
    public string Prompt { get; set; }

    public string Response { get; internal set; }

    public async void PostPromptAsync()
    {
        var result = await chatApiClient.PostPromptAsync(this.Prompt);
        this.Response = result.response;
    }
}
