using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Utility
    {
        public static long LCM(long[] values)
        {
            var increases = values.Min();
            var result = values.Max() * increases;
            bool found;
            while (true)
            {
                found = true;
                foreach (var v in values)
                {
                    if (v == 0) return 0L;

                    if (result % v != 0)
                    {
                        found = false;
                        break;
                    }
                }
                if (found) break;

                result += increases;
            }

            return result;
        }
    }
}
