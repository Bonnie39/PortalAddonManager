using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAddonManager.Scripts
{
    public static class Concat
    {
        public static T[] Concatenate<T>(this T[] first, T[] second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            return first.Concat(second).ToArray();
        }
    }
}
