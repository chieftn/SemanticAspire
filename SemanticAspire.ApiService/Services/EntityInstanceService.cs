using SemanticAspire.ApiService.Models;

namespace SemanticAspire.ApiService.Services;

interface IEntityInstanceService
{
    Task<EntityModel> AcquireModelAsync(
        int entityId,
        CancellationToken cancellationToken = default);
}

public class EntityInstanceService
{
    public async Task<IEnumerable<EntityInstance>> GetEntityInstancesAsync(int entityId, CancellationToken cancellationToken = default)
    {
        await Task.Delay(1000);
        return GetEntityInstances();
    }

    public List<EntityInstance> GetEntityInstances()
    {
        List<EntityInstance> entityInstances = new List<EntityInstance>
        {
            new EntityInstance()
            {
                Id = 1000,
                EntityType = 0,
                Name = "Production Line A",
                Properties = new Dictionary<string, double> {
                    ["Efficiency"] = 93.6,
                    ["Throughput"] = 753.48,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Efficiency Over Time"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 47.91 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 17.83 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 61.67 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 50.04 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 59.22 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 98.31 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 17.89 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 76.64 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 50.97 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 27.92 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 89.48 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 21.3 },
                    },
                    ["Product Output Rate"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 32.46 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 31.69 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 98.39 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 70.65 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 83.49 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 40.41 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 65.71 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 79.88 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 97.41 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 58.86 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 20.33 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 73.56 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1001,
                EntityType = 1,
                Name = "VAT in Production Line A",
                Properties = new Dictionary<string, double> {
                    ["Volume Capacity"] = 40.73,
                    ["Temperature"] = 53.94,
                    ["Viscosity"] = 89.65,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Temperature Fluctuations"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 79.93 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 84.75 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 47.54 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 31.7 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 26.38 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 34.34 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 65.71 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 85.89 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 47.89 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 34.91 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 94.78 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 64.37 },
                    },
                    ["Viscosity Trends"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 75.42 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 77.06 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 26.94 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 71.47 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 58.39 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 77.64 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 71.21 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 32.08 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 63.55 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 39.14 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 27.79 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 21.52 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1002,
                EntityType = 2,
                Name = "Oven in Production Line A",
                Properties = new Dictionary<string, double> {
                    ["Max Temperature"] = 64.25,
                    ["Energy Consumption"] = 72.72,
                    ["Bake Time"] = 54.32,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Heat Distribution"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 53.3 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 87.51 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 96.9 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 74.16 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 60.77 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 11.65 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 18.79 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 56.85 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 51.19 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 82.62 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 94.13 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 88.81 },
                    },
                    ["Power Consumption Over Time"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 83.5 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 49.6 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 88.38 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 58.18 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 36.33 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 66.44 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 39.57 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 21.29 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 53.19 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 67.95 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 11.06 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 88.21 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1003,
                EntityType = 3,
                Name = "Extruder in Production Line A",
                Properties = new Dictionary<string, double> {
                    ["Pressure"] = 80.23,
                    ["Flow Rate"] = 92.55,
                    ["Torque"] = 51.47,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Pressure Variations"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 66.65 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 89.5 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 99.2 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 60.08 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 55.88 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 44.86 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 12.33 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 13.96 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 75.43 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 26.37 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 44.24 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 44.36 },
                    },
                    ["Material Flow Trends"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 77.04 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 67.06 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 27.63 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 34.16 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 54.31 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 35.24 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 21.19 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 30.47 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 82.35 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 13.38 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 55.24 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 86.75 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1004,
                EntityType = 4,
                Name = "Conveyor in Production Line A",
                Properties = new Dictionary<string, double> {
                    ["Speed"] = 82.76,
                    ["Load Capacity"] = 27.59,
                    ["Belt Wear"] = 99.16,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Speed Variations"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 41.57 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 59.9 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 24.13 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 38.14 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 53.57 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 46.43 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 18.5 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 46.79 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 78.01 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 31.29 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 43.95 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 57.29 },
                    },
                    ["Load Capacity Over Time"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 32.55 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 97.3 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 18.96 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 22.78 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 85.81 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 65.15 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 85.93 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 33.57 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 86.54 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 99.57 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 41.47 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 22.66 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1005,
                EntityType = 0,
                Name = "Production Line B",
                Properties = new Dictionary<string, double> {
                    ["Efficiency"] = 77.26,
                    ["Throughput"] = 910.52,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Efficiency Over Time"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 46.23 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 38.78 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 58.31 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 76.47 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 19.64 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 81.68 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 85.63 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 80.83 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 37.93 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 56.82 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 72.67 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 67.67 },
                    },
                    ["Product Output Rate"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 66.08 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 91.7 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 98.73 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 44.08 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 20.1 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 51.18 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 21.49 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 37.66 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 81.64 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 95.7 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 14.17 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 86.82 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1006,
                EntityType = 1,
                Name = "VAT in Production Line B",
                Properties = new Dictionary<string, double> {
                    ["Volume Capacity"] = 97.15,
                    ["Temperature"] = 65.41,
                    ["Viscosity"] = 44.26,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Temperature Fluctuations"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 62.51 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 15.34 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 47.93 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 59.58 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 75.43 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 70.42 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 40.52 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 50.96 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 59.42 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 10.77 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 97.75 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 88.83 },
                    },
                    ["Viscosity Trends"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 27.38 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 44.79 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 13.77 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 39.13 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 18.64 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 64.59 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 11.71 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 88.2 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 73.95 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 60.36 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 43.67 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 41.67 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1007,
                EntityType = 2,
                Name = "Oven in Production Line B",
                Properties = new Dictionary<string, double> {
                    ["Max Temperature"] = 75.36,
                    ["Energy Consumption"] = 59.92,
                    ["Bake Time"] = 77.42,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Heat Distribution"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 84.21 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 64.81 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 91.1 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 46.63 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 84.82 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 94.87 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 97.64 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 34.36 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 17.16 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 57.28 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 32.45 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 10.81 },
                    },
                    ["Power Consumption Over Time"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 70.64 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 57.72 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 97.14 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 52.67 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 46.1 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 24.59 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 39.0 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 82.5 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 31.98 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 60.72 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 58.25 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 19.17 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1008,
                EntityType = 3,
                Name = "Extruder in Production Line B",
                Properties = new Dictionary<string, double> {
                    ["Pressure"] = 89.13,
                    ["Flow Rate"] = 88.53,
                    ["Torque"] = 77.07,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Pressure Variations"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 15.35 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 55.69 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 83.39 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 44.83 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 29.79 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 49.09 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 69.02 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 73.84 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 47.69 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 12.97 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 45.33 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 30.26 },
                    },
                    ["Material Flow Trends"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 36.75 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 44.38 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 23.74 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 34.14 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 65.07 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 25.52 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 97.82 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 55.84 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 35.86 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 45.12 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 73.37 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 13.99 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1009,
                EntityType = 4,
                Name = "Conveyor in Production Line B",
                Properties = new Dictionary<string, double> {
                    ["Speed"] = 10.81,
                    ["Load Capacity"] = 55.11,
                    ["Belt Wear"] = 47.57,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Speed Variations"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 86.45 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 30.77 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 54.59 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 90.7 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 34.33 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 74.46 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 39.68 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 56.5 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 52.75 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 22.29 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 32.8 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 66.93 },
                    },
                    ["Load Capacity Over Time"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 31.33 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 18.07 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 27.53 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 40.49 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 35.26 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 78.66 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 39.07 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 40.8 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 91.95 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 18.65 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 13.53 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 42.13 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1010,
                EntityType = 0,
                Name = "Production Line C",
                Properties = new Dictionary<string, double> {
                    ["Efficiency"] = 70.92,
                    ["Throughput"] = 757.79,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Efficiency Over Time"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 49.14 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 63.97 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 73.98 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 59.43 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 22.27 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 67.63 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 93.9 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 97.9 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 98.79 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 83.17 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 61.37 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 14.24 },
                    },
                    ["Product Output Rate"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 11.82 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 14.09 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 14.34 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 51.62 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 45.56 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 94.19 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 11.64 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 77.41 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 60.08 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 67.16 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 81.93 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 12.62 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1011,
                EntityType = 1,
                Name = "VAT in Production Line C",
                Properties = new Dictionary<string, double> {
                    ["Volume Capacity"] = 98.63,
                    ["Temperature"] = 45.2,
                    ["Viscosity"] = 16.88,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Temperature Fluctuations"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 25.57 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 80.05 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 45.62 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 38.89 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 19.75 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 45.26 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 76.95 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 56.72 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 74.91 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 47.42 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 24.98 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 97.73 },
                    },
                    ["Viscosity Trends"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 96.43 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 19.03 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 10.68 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 14.94 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 32.95 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 43.15 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 68.25 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 18.69 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 44.85 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 34.86 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 51.18 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 66.89 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1012,
                EntityType = 2,
                Name = "Oven in Production Line C",
                Properties = new Dictionary<string, double> {
                    ["Max Temperature"] = 59.02,
                    ["Energy Consumption"] = 72.8,
                    ["Bake Time"] = 43.94,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Heat Distribution"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 36.26 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 27.02 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 59.17 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 45.13 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 12.13 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 19.93 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 95.02 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 52.07 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 10.87 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 77.59 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 64.33 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 33.35 },
                    },
                    ["Power Consumption Over Time"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 17.89 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 88.15 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 53.55 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 49.94 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 32.99 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 57.94 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 15.38 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 76.36 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 69.18 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 38.54 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 54.86 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 93.44 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1013,
                EntityType = 3,
                Name = "Extruder in Production Line C",
                Properties = new Dictionary<string, double> {
                    ["Pressure"] = 14.55,
                    ["Flow Rate"] = 70.79,
                    ["Torque"] = 36.11,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Pressure Variations"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 48.31 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 59.11 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 50.16 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 38.14 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 19.88 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 48.42 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 34.86 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 43.68 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 92.78 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 67.76 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 48.26 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 58.64 },
                    },
                    ["Material Flow Trends"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 49.72 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 96.95 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 46.73 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 91.93 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 90.52 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 97.06 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 45.51 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 29.42 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 94.54 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 90.06 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 51.48 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 65.71 },
                    },
                }
            },
            new EntityInstance()
            {
                Id = 1014,
                EntityType = 4,
                Name = "Conveyor in Production Line C",
                Properties = new Dictionary<string, double> {
                    ["Speed"] = 73.37,
                    ["Load Capacity"] = 42.29,
                    ["Belt Wear"] = 78.3,
                },
                TimeSeries = new Dictionary<string, List<TimeSeriesData>>
                {
                    ["Speed Variations"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 70.17 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 35.72 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 86.62 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 37.95 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 14.88 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 29.41 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 63.95 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 32.84 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 12.73 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 79.37 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 48.36 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 19.84 },
                    },
                    ["Load Capacity Over Time"] = new List<TimeSeriesData>
                    {
                        new TimeSeriesData() { Timestamp = "2025-02-23 16:38:40", Value = 64.58 },
                        new TimeSeriesData() { Timestamp = "2025-02-24 16:38:40", Value = 42.59 },
                        new TimeSeriesData() { Timestamp = "2025-02-25 16:38:40", Value = 47.73 },
                        new TimeSeriesData() { Timestamp = "2025-02-26 16:38:40", Value = 34.56 },
                        new TimeSeriesData() { Timestamp = "2025-02-27 16:38:40", Value = 17.58 },
                        new TimeSeriesData() { Timestamp = "2025-02-28 16:38:40", Value = 49.72 },
                        new TimeSeriesData() { Timestamp = "2025-03-01 16:38:40", Value = 51.58 },
                        new TimeSeriesData() { Timestamp = "2025-03-02 16:38:40", Value = 12.89 },
                        new TimeSeriesData() { Timestamp = "2025-03-03 16:38:40", Value = 93.29 },
                        new TimeSeriesData() { Timestamp = "2025-03-04 16:38:40", Value = 47.84 },
                        new TimeSeriesData() { Timestamp = "2025-03-05 16:38:40", Value = 10.63 },
                        new TimeSeriesData() { Timestamp = "2025-03-06 16:38:40", Value = 31.46 },
                    },
                }
            },
        };

        return entityInstances;
    };
}
