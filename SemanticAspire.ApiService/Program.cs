using SemanticAspire.ApiService;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

builder.Configuration.AddAzureKeyVaultSecrets("secrets");
builder.AddAzureKeyVaultClient("secrets");

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();
app.UseExceptionHandler();
app.MapSecretsEndpoints();
app.MapChatEndpoints();
app.MapDefaultEndpoints();
app.Run();
