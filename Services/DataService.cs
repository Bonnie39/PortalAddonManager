using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalAddonManager.Models;

namespace PortalAddonManager.Services
{
    public class DataService
    {
        private List<Repository> repos;

        public List<Repository> Repos
        {
            get => repos ??= new List<Repository>();
            set => repos = value;
        }
    }
}
