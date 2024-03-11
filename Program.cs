using advent5;

// Adam: My steps:

Console.WriteLine("Hello farmer!");

// 1. Load file to some structure. -> FileParser.cs
var input = FileParser.ParseFile("input.txt");

// 2. Create mappings -> FarmMappings.cs
var mappings = FarmMappings.CreateMapping(input);

// 3. Use farm mapping (seed-> location to map and select min location)
var minLocation = input.seeds.Select(x => mappings(x)).Min();

Console.WriteLine($"Min location: {minLocation}");
