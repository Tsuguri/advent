using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent5
{
    struct InputData
    {
        public List<uint> seeds;
        public Mapping seedToSoil;
        public Mapping soilToFertilizer;
        public Mapping fertilizerToWater;
        public Mapping waterToLight;
        public Mapping lightToTemperature;
        public Mapping temperatureToHumidity;
        public Mapping humidityToLocation;
    }

    internal class FileParser
    {
        static List<Mapping.SingleEntry> ReadMappingEntries(List<string> lines, ref int currentLine)
        {
            var result = new List<Mapping.SingleEntry>();
            while (currentLine < lines.Count && lines[currentLine] != "")
            {
                var values = lines[currentLine].Split(" ").Select(str => uint.Parse(str)).ToList();
                Debug.Assert(values.Count == 3);
                result.Add(new Mapping.SingleEntry { to = values[0], from = values[1], rangeLength = values[2] });
                currentLine++;
            }
            return result;
        }

        static Mapping ReadBlock(List<string> lines, ref int currentLine)
        {
            var result = ReadMappingEntries(lines, ref currentLine);
            currentLine += 2; // skip empty and text lines
            return new Mapping(result);
        }

        public static InputData ParseFile(string filename)
        {
            var result = new InputData();
            var lines = File.ReadAllLines("input.txt").ToList();

            result.seeds = lines[0].Split(" ").Skip(1).Select(str => uint.Parse(str)).ToList();

            // line 1 is empty
            // line 2 is text
            int currentLine = 3;

            result.seedToSoil = ReadBlock(lines, ref currentLine);
            result.soilToFertilizer = ReadBlock(lines, ref currentLine);
            result.fertilizerToWater = ReadBlock(lines, ref currentLine);
            result.waterToLight = ReadBlock(lines, ref currentLine);
            result.lightToTemperature = ReadBlock   (lines, ref currentLine);
            result.temperatureToHumidity = ReadBlock(lines, ref currentLine);
            result.humidityToLocation = ReadBlock(lines, ref currentLine);

            return result;
        }
    }
}
