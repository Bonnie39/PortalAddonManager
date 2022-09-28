using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace PortalAddonManager
{
    [Serializable]
    internal class GameDataPaths
    {
        public static string? steamPath;
        public static string? portalAddonPath;

        private void TryLoadSerializedData()
        {

        }
    }
}
