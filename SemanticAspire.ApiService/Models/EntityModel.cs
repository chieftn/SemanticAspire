namespace SemanticAspire.ApiService.Models;

public class EntityModelNode
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<string> Properties { get; set; }
}

public class EntityModelRelationship
{
    public int Source { get; set; }
    public int Target { get; set; }
    public string Name { get; set; }
}

public class EntityModel
{
    public IEnumerable<EntityModelNode> Nodes { get; set; }
    public IEnumerable<EntityModelRelationship> Relationships { get; set; }
}