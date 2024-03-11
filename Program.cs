using advent5;
using System.Diagnostics;

// Adam: My steps:

Console.WriteLine("Hello farmer!");

// 1. Load file to some structure. -> FileParser.cs
var input = FileParser.ParseFile("input.txt");

// 2. Create mappings -> FarmMappings.cs
var mappings = FarmMappings.CreateMapping(input);

// 3. Use farm mapping (seed-> location to map and select min location)
var minLocation = input.seeds.Select(x => mappings(x)).Min();

// 4. Changed FileParser.cs to produce Mappings directly instead of List<tuple<uint, uint, uint>.

Console.WriteLine($"Min location: {minLocation}");

// 5. use advanced farming techniques to differently use seed values

Debug.Assert(input.seeds.Count % 2 == 0); // there are pair of values - ranges

// would be nicer to have https://stackoverflow.com/questions/5215469/use-linq-to-break-up-listt-into-lots-of-listt-of-n-length but don't want to copy
var seed_ranges = new List<IEnumerable<uint>>();
for (int i = 0; i < input.seeds.Count;i+=2)
{
    seed_ranges.Add(AdvancedFarming.SeedRange(input.seeds[i], input.seeds[i + 1]));
}

var advancedMinLocation = seed_ranges.SelectMany(x => x).AsParallel().Select(seed => mappings((uint)seed)).Min();

Console.WriteLine($"Advanced min location: {advancedMinLocation}");

