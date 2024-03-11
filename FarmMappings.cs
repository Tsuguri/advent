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
        // could be faster with some kind of binary search.
        foreach (SingleEntry entry in entries)
        {
            if (value >= entry.from && value < entry.from + entry.rangeLength)
            {
                return value - entry.from + entry.to;
            }
        }
        return value;
    }

    public Mapping(List<SingleEntry> entries)
    {
        this.entries = entries;
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
    internal static Func<uint, uint> CreateMapping(InputData input)
    {
        return seed =>
        {
            // Initially wanted to do .Map(..).Map(..).Map(..) but it's hard to place breakpoints and see on stack trace which Map is running.
            // I don't like the fact that it's using the same objects as input. Would prefer deep copy there for lambda to be self-contained.
            var soil = seed.Map(input.seedToSoil);
            var fertilizer = soil.Map(input.soilToFertilizer);
            var water = fertilizer.Map(input.fertilizerToWater);
            var light = water.Map(input.waterToLight);
            var temperature = light.Map(input.lightToTemperature);
            var humidity = temperature.Map(input.temperatureToHumidity);
            var location = humidity.Map(input.humidityToLocation);
            return location;
        };
    }
}