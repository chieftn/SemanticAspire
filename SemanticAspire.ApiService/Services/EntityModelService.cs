using SemanticAspire.ApiService.Models;

namespace SemanticAspire.ApiService;

interface IEntityModelService
{
    Task<EntityModel> AcquireModelAsync(
        string entityName,
        CancellationToken cancellationToken = default);
}

public class EntityModelService : IEntityModelService
{
    public async Task<EntityModel> AcquireModelAsync(string entityName, CancellationToken cancellationToken = default)
    {
        await Task.Delay(1000);
        return GetEntityModel();
    }

    private EntityModel GetEntityModel()
    {
        var nodes = new List<EntityModelNode>() {
            new EntityModelNode() {
                Id = 0,
                Name = "Production Line",
                Description = "Automated system for manufacturing products.",
                Properties = new List<string> {"Efficiency", "Throughput"},
                TimeSeries = new List<string> {"Efficiency Over Time", "Product Output Rate"}
            },
            new EntityModelNode() {
                Id = 1,
                Name = "VAT",
                Description = "Large container for mixing raw materials.",
                Properties = new List<string> {"Volume Capacity", "Temperature"},
                TimeSeries = new List<string> {"Temperature Fluctuations", "Viscosity Trends"}
            },
            new EntityModelNode() {
                Id = 2,
                Name = "Oven",
                Description = "High-temperature chamber for baking or processing.",
                Properties = new List<string> {"Max Temperature", "Energy Consumption"},
                TimeSeries = new List<string> {"Heat Distribution", "Power Consumption Over Time"}
            },
            new EntityModelNode() {
                Id = 3,
                Name = "Extruder",
                Description = "Machine that shapes material through force.",
                Properties = new List<string> {"Pressure", "Flow Rate"},
                TimeSeries = new List<string> {"Pressure Variations", "Material Flow Trends"}
            },
            new EntityModelNode() {
                Id = 4,
                Name = "Conveyor",
                Description = "Moving belt system for transporting goods.",
                Properties = new List<string> {"Speed", "Load Capacity"},
                TimeSeries = new List<string> {"Speed Variations", "Load Capacity Over Time"}
            },
            new EntityModelNode() {
                Id = 5,
                Name = "Tensioner",
                Description = "Device ensuring optimal belt tightness.",
                Properties = new List<string> {"Tension Force", "Belt Slippage"},
                TimeSeries = new List<string> {"Tension Force Trends", "Wear Analysis"}
            },
            new EntityModelNode() {
                Id = 6,
                Name = "Rollerset",
                Description = "Set of rollers guiding material flow.",
                Properties = new List<string> {"Rotation Speed", "Friction Coefficient"},
                TimeSeries = new List<string> {"Rotation Stability", "Wear and Tear Over Time"}
            },
            new EntityModelNode() {
                Id = 7,
                Name = "Motor",
                Description = "Power source driving mechanical movement.",
                Properties = new List<string> {"Power Output", "RPM"},
                TimeSeries = new List<string> {"Power Draw Over Time", "RPM Variability"}
            },
            new EntityModelNode() {
                Id = 8,
                Name = "Packing Line",
                Description = "Automated system for product packaging.",
                Properties = new List<string> {"Package Rate", "Error Count"},
                TimeSeries = new List<string> {"Packaging Errors Over Time", "Production Rate"}
            },
            new EntityModelNode() {
                Id = 9,
                Name = "Ground Scale",
                Description = "Weighing system for heavy materials.",
                Properties = new List<string> {"Max Weight", "Accuracy"},
                TimeSeries = new List<string> {"Weight Measurement Accuracy", "Usage Trends"}
            },
            new EntityModelNode() {
                Id = 10,
                Name = "Packer",
                Description = "Machine for sealing and packaging items.",
                Properties = new List<string> {"Seal Integrity", "Speed"},
                TimeSeries = new List<string> {"Seal Success Rate", "Throughput Over Time"}
            },
            new EntityModelNode() {
                Id = 11,
                Name = "Elevation Scale",
                Description = "Height-based measurement system.",
                Properties = new List<string> {"Height Limit", "Calibration Status"},
                TimeSeries = new List<string> {"Height Adjustment Over Time", "Sensor Stability"}
            },
            new EntityModelNode() {
                Id = 12,
                Name = "Suspension Unit",
                Description = "Support structure for hanging components.",
                Properties = new List<string> {"Load Capacity", "Damping Ratio"},
                TimeSeries = new List<string> {"Shock Absorption Trends", "Load Handling Efficiency"}
            },
            new EntityModelNode() {
                Id = 13,
                Name = "Intake",
                Description = "Entry point for raw materials.",
                Properties = new List<string> {"Flow Rate", "Filter Status"},
                TimeSeries = new List<string> {"Flow Rate Over Time", "Filter Efficiency"}
            },
            new EntityModelNode() {
                Id = 14,
                Name = "Kicker",
                Description = "Ejector mechanism for sorting items.",
                Properties = new List<string> {"Activation Speed", "Sorting Accuracy"},
                TimeSeries = new List<string> {"Sorting Efficiency Trends", "Activation Delays"}
            },
        };

        var relationships = new List<EntityModelRelationship>()
        {
             new EntityModelRelationship()
            {
                Source = 0,
                Target = 1,
                Name = "contains"
            },
            new EntityModelRelationship()
            {
                Source = 1,
                Target = 2,
                Name = "feeds"
            },
            new EntityModelRelationship()
            {
                Source = 2,
                Target = 3,
                Name = "feeds"
            },
            new EntityModelRelationship()
            {
                Source = 0,
                Target = 4,
                Name = "contains"
            },
            new EntityModelRelationship()
            {
                Source = 4,
                Target = 5,
                Name = "hasComponent"
            },
            new EntityModelRelationship()
            {
                Source = 5,
                Target = 6,
                Name = "hasComponent"
            },
            new EntityModelRelationship()
            {
                Source = 4,
                Target = 7,
                Name = "hasComponent"
            },
            new EntityModelRelationship()
            {
                Source = 7,
                Target = 6,
                Name = "feeds"
            },
            new EntityModelRelationship()
            {
                Source = 0,
                Target = 8,
                Name = "feeds"
            },
            new EntityModelRelationship()
            {
                Source = 8,
                Target = 9,
                Name = "contains"
            },
            new EntityModelRelationship()
            {
                Source = 8,
                Target = 10,
                Name = "contains"
            },
            new EntityModelRelationship()
            {
                Source = 8,
                Target = 11,
                Name = "contains"
            },
            new EntityModelRelationship()
            {
                Source = 11,
                Target = 12,
                Name = "hasComponent"
            },
            new EntityModelRelationship()
            {
                Source = 11,
                Target = 13,
                Name = "hasComponent"
            },
            new EntityModelRelationship()
            {
                Source = 10,
                Target = 14,
                Name = "hasComponent"
            },
        };

        return new EntityModel()
        {
            Nodes = nodes,
            Relationships = relationships
        };
    }
}

