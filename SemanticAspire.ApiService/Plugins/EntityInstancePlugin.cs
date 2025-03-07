using Microsoft.SemanticKernel;
using SemanticAspire.ApiService.Models;
using SemanticAspire.ApiService.Services;
using System.ComponentModel;

namespace SemanticAspire.ApiService.Plugins;
public class EntityInstancePlugin
{
    [KernelFunction("Entity_Model_Database_Search")]
    [Description("retrieves entity instances.")]
    public async Task<IEnumerable<EntityInstance>> SearchAsync(
        int entityId,
        CancellationToken cancellationToken = default)
    {
        var entityInstanceService = new EntityInstanceService();
        return await entityInstanceService.GetEntityInstancesAsync(entityId, cancellationToken);
    }
}
