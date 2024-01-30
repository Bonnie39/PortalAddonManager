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
        public string? description { get; set; }
        public string? iconURL { get; set; }
        public string? website { get; set; }
        public List<Package>? packages { get; set; }
    }

    public class Package
    {
        public string? name { get; set; }
        public string? authorName { get; set; }
        public string? subtitle { get; set; }
        public string? iconURL { get; set; }
        public List<string>? screenshotURLs { get; set; }
        public List<Version>? versions { get; set; }
    }

    public class Version
    {
        public string? version { get; set; }
        public DateTime? date { get; set; }
        public string? description { get; set; }
        public string? vpkURL { get; set; }
        public string? jsonURL { get; set; }
        public string? size_mb { get; set; }
    }
}
