using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent5
{
    class AdvancedFarming
    {
        public static IEnumerable<uint> SeedRange(uint from, uint elements)
        {
            for (uint i = 0; i < elements; i++)
            {
                yield return from + i;
            }
        }
    }
}
