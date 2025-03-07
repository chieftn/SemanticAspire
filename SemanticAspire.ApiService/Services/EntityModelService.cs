using SemanticAspire.ApiService.Models;

namespace SemanticAspire.ApiService;

interface IModelService
{
    Task<EntityModel> AcquireModelAsync(
        string entityName,
        CancellationToken cancellationToken = default);
}

public class ModelService : IModelService
{
    public Task<EntityModel> AcquireModelAsync(string entityName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}