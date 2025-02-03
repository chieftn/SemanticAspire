using SemanticAspire.ApiService;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

builder.Configuration.AddAzureKeyVaultSecrets("secrets");
builder.AddAzureKeyVaultClient("secrets");
builder.AddRedisClient(connectionName: "cache");

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddChatHistoryService();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();
app.UseExceptionHandler();
app.MapSecretsEndpoints();
app.MapChatEndpoints();
app.MapPretzelAgentsEndpoints();
app.MapPretzelAgentEndpoints();
app.MapIncidentEndpoints();
app.MapDefaultEndpoints();

app.Run();
