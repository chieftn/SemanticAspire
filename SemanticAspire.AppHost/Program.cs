var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var secrets =
    builder.ExecutionContext.IsPublishMode
        ? builder.AddAzureKeyVault("secrets")
        : builder.AddConnectionString("secrets");


var apiService = builder.AddProject<Projects.SemanticAspire_ApiService>("apiservice")
    .WithReference(secrets);

// builder.AddDockerfile("web", "../SemanticAspire.React", "DockerFile");

builder.AddNpmApp("react", "../SemanticAspire.React")
    .WithEnvironment("BROWSER", "none") // Disable opening browser on npm start
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
