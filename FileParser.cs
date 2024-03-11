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
        public List<Tuple<uint, uint, uint>> seedToSoil;
        public List<Tuple<uint, uint, uint>> soilToFertilizer;
        public List<Tuple<uint, uint, uint>> fertilizerToWater;
        public List<Tuple<uint, uint, uint>> waterToLight;
        public List<Tuple<uint, uint, uint>> lightToTemperature;
        public List<Tuple<uint, uint, uint>> temperatureToHumidity;
        public List<Tuple<uint, uint, uint>> humidityToLocation;
    }
    internal class FileParser
    {
        static List<Tuple<uint, uint, uint>> ReadTuples(List<string> lines, ref int currentLine)
        {
            var result = new List<Tuple<uint, uint, uint>>();
            while (currentLine < lines.Count && lines[currentLine] != "")
            {
                var values = lines[currentLine].Split(" ").Select(str => uint.Parse(str)).ToList();
                Debug.Assert(values.Count == 3);
                result.Add(new Tuple<uint, uint, uint>(values[0], values[1], values[2]));
                currentLine++;
            }
            return result;
        }

        public static InputData ParseFile(string filename)
        {
            var result = new InputData();
            var lines = File.ReadAllLines("input.txt").ToList();

            result.seeds = lines[0].Split(" ").Skip(1).Select(str => uint.Parse(str)).ToList();

            // line 1 is empty
            // line 2 is text
            int currentLine = 3;

            result.seedToSoil = ReadTuples(lines, ref currentLine); currentLine += 2;
            result.soilToFertilizer = ReadTuples(lines, ref currentLine); currentLine += 2;
            result.fertilizerToWater = ReadTuples(lines, ref currentLine); currentLine += 2;
            result.waterToLight = ReadTuples(lines, ref currentLine); currentLine += 2;
            result.lightToTemperature = ReadTuples(lines, ref currentLine); currentLine += 2;
            result.temperatureToHumidity = ReadTuples(lines, ref currentLine); currentLine += 2;
            result.humidityToLocation = ReadTuples(lines, ref currentLine);





            return result;
        }
    }
}
