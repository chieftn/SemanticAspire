var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var secrets =
    builder.ExecutionContext.IsPublishMode
        ? builder.AddAzureKeyVault("secrets")
        : builder.AddConnectionString("secrets");


var apiService = builder.AddProject<Projects.SemanticAspire_ApiService>("apiservice")
    .WithReference(secrets);

builder.AddNpmApp("react", "../SemanticAspire.React")
    .WithReference(apiService)
    .WithEnvironment("BROWSER", "none") // Disable opening browser on npm start
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

// Disabling Blazor App
//builder.AddProject<Projects.SemanticAspire_Web>("webfrontend")
//    .WithExternalHttpEndpoints()
//    .WithReference(cache)
//    .WaitFor(cache)
//    .WithReference(apiService)
//    .WaitFor(apiService);

builder.Build().Run();
