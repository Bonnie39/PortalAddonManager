using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalAddonManager.Models
{
    public class Repository
    {
        public string? name { get; set; }
        public string? iconURL { get; set; }
        public List<Package>? packages { get; set; }
    }

    public class Package
    {
        public string? name { get; set; }
        public string? iconURL { get; set; }
    }
}
