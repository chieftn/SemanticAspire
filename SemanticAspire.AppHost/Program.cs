var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var secrets =
    builder.ExecutionContext.IsPublishMode
        ? builder.AddAzureKeyVault("secrets")
        : builder.AddConnectionString("secrets");

var apiService = builder.AddProject<Projects.SemanticAspire_ApiService>("apiservice")
    .WithReference(secrets);

builder.AddProject<Projects.SemanticAspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
