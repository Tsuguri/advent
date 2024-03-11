using advent5;

// Adam: steps:
// 1. represent single entry
// 2. create Mapping.Map
// 3. construct entire mapping pipeline with Mappings in FarmMappings

class Mapping
{
    internal struct SingleEntry
    {
        public uint from;
        public uint to;
        public uint rangeLength;
    }

    List<SingleEntry> entries;

    public uint Map(uint value)
    {
        // could be faster with some kind of binary search
        foreach (SingleEntry entry in entries)
        {
            if (value >= entry.from && value < entry.from + entry.rangeLength)
            {
                return value - entry.from + entry.to;
            }
        }
        return value;
    }

    public Mapping(List<Tuple<uint, uint, uint>> tuples)
    {
        entries = tuples.Select(x => new SingleEntry { from = x.Item2, to = x.Item1, rangeLength = x.Item3 }).ToList();
    }

}

internal static class UintMappingExtensions
{
    public static uint Map(this uint value, Mapping map)
    {
        return map.Map(value);
    }
}
internal class FarmMappings
{
    internal static Func<uint, uint?> CreateMapping(InputData input)
    {
        var seedToSoil = new Mapping(input.seedToSoil);
        var soilToFertilizer = new Mapping(input.soilToFertilizer);
        var fertilizerToWater = new Mapping(input.fertilizerToWater);
        var waterToLight = new Mapping(input.waterToLight);
        var lightToTemperature = new Mapping(input.lightToTemperature);
        var temperatureToHumidity = new Mapping(input.temperatureToHumidity);
        var humidityToLocation = new Mapping(input.humidityToLocation);

        return x =>
        {
            var soil = x.Map(seedToSoil);
            var fertilizer = soil.Map(soilToFertilizer);
            var water = fertilizer.Map(fertilizerToWater);
            var light = water.Map(waterToLight);
            var temperature = light.Map(lightToTemperature);
            var humidity = temperature.Map(temperatureToHumidity);
            var location = humidity.Map(humidityToLocation);
            return location;
        };
    }
}