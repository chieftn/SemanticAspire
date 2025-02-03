using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace SemanticAspire.Plugins;

public class PretzelMeasure
{
    public int Weight { get; set; }
    public int Sponginess { get; set; }

    public int CrustHardness { get; set; }
}

public class PretzelInputs
{
    public int WaterTemperature { get; set; }
    public int OvenCooktime { get; set; }
    public int CoolingTime { get; set; }
}

internal class PretzelStatistics
{
    [KernelFunction("preztel_quality_statistics")]
    [Description("Get quality measurements of pretzels for a specific line")]
    [return: Description("description of quality metrics for pretzel line")]
    public PretzelMeasure GetPretzelStatistics(Kernel kernel, string lineName)
    {
        Random rnd = new();

        if (lineName.ToLowerInvariant() == "a")
        {
            var measure = new PretzelMeasure
            {
                Weight = rnd.Next(1, 2),
                Sponginess = rnd.Next(100, 200),
                CrustHardness = rnd.Next(10, 12),
            };

            return measure;
        }

        return new PretzelMeasure
        {
            Weight = rnd.Next(2, 3),
            Sponginess = rnd.Next(250, 250),
            CrustHardness = rnd.Next(15, 17),
        };
    }

    [KernelFunction("preztel_inputs")]
    [Description("Get the inputs for a specific line")]
    [return: Description("description of pretzel line inputs")]
    public PretzelInputs GetPretzelInputs(Kernel kernel, string lineName)
    {
        Random rnd = new();

        if (lineName.ToLowerInvariant() == "a")
        {
            var measure = new PretzelInputs
            {
                WaterTemperature = rnd.Next(90, 100),
                OvenCooktime = rnd.Next(10, 22),
                CoolingTime = rnd.Next(10, 12),
            };

            return measure;
        }

        return new PretzelInputs
        {
            WaterTemperature = rnd.Next(110, 120),
            OvenCooktime = rnd.Next(10, 12),
            CoolingTime = rnd.Next(15, 17),
        };
    }
}
