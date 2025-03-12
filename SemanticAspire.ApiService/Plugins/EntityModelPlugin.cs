using Microsoft.SemanticKernel;
using SemanticAspire.ApiService.Models;
using System.ComponentModel;

namespace SemanticAspire.ApiService.Plugins;
public class EntityModelPlugin
{
    [KernelFunction("Entity_Model_Database_Search")]
    [Description("retrieves a portion of the overall entity model.")]
    public async Task<EntityModel> SearchAsync(
        string query,
        CancellationToken cancellationToken = default)
    {
        var entityModelService = new EntityModelService();
        return await entityModelService.AcquireModelAsync(query, cancellationToken);
    }
}
